using api.evl.watch.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace api.evl.watch.Handlers
{
    public class ExceptionsHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var controller = (ApiController)context.ActionContext.ControllerContext.Controller;

            using (var ctx = new EvlWatchContext())
            {
                ctx.ExecuteStoreCommand("EXEC dbo.InsertApiErrorLog @id, @exception",
                             new SqlParameter("id", controller.Request.Properties["RequestID"]),
                             new SqlParameter("exception", $"Message: {context.Exception.Message}\nSource: {context.Exception.Source}\nStack: {context.Exception.StackTrace}"));
            }

            throw new HttpResponseException(context.Request.CreateResponse(
                new DefaultResponseModel<Dictionary<string,string>>(controller, HttpStatusCode.InternalServerError)
                {
                    Data = new Dictionary<string, string>()
                    {
                        { "Message", "An error occurred, please try again or contact the administrator. Remember to provide your ResponseID." },
                        { "Contact", "errors@evl.watch" }

                    }
                })
            );
        }

    }

}