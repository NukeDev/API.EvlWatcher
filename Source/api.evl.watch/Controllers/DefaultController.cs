using api.evl.watch.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.evl.watch.Controllers
{
    public class DefaultController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new DefaultResponseModel<string>(this, HttpStatusCode.OK)
            {
                Data = "WebAPI Access"
            });
        }
    }
}
