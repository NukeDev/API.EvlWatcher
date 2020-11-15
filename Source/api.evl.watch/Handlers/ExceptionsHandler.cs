using api.evl.watch.Models;
using api.evl.watch.Utils;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Filters;

namespace api.evl.watch.Handlers
{
    public class ExceptionsHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            var controller = (ApiController)context.ActionContext.ControllerContext.Controller;

            var error = ErrorUtils.GetError(controller.Request);
            error.SetException(context.Exception);
            using (var ctx = new EvlWatchContext())
            {
                ctx.ExecuteStoreCommand("EXEC dbo.InsertApiErrorLog @id, @exception",
                             new SqlParameter("id", controller.Request.Properties["RequestID"]),
                             new SqlParameter("exception", $"Message: {context.Exception.Message}\nSource: {context.Exception.Source}\nStack: {context.Exception.StackTrace}"));
            }

            throw new HttpResponseException(context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new DefaultResponseModel<ErrorType>(controller, HttpStatusCode.InternalServerError)
                {
                    Data = error
                })
            );
        }

    }

}