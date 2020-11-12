using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace api.evl.watch.Models
{
    public class DefaultResponseModel<T>
    {
        public string ResponseID { get; private set; }
        public HttpStatusCode ResponseStatusCode { get; private set; }
        public DateTimeOffset ResponseDateTime { get; private set; }
        public string RequestMethod { get; private set; }
        public string IPAddress { get; private set; }
        public T Data { get; set; }

        public DefaultResponseModel(ApiController controller, HttpStatusCode code)
        {
            ResponseDateTime = DateTimeOffset.Now;
            RequestMethod = controller.Request.Method.ToString();
            ResponseStatusCode = code;
            if ( controller.Request.Properties.ContainsKey("MS_HttpContext") )
            {
                var ctx = controller.Request.Properties["MS_HttpContext"] as HttpContextBase;
                if ( ctx != null )
                {
                    IPAddress = ctx.Request.UserHostAddress;
                }
                else
                {
                    IPAddress = "--";
                }
            }
            ResponseID = controller.Request.Properties.FirstOrDefault(x => x.Key == "RequestID").Value.ToString();
        }
    }
}