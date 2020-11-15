using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.evl.watch.Models
{
    public enum ErrorTypeCode
    {
        UnhandledError = 99,
        InvalidUserRegisteringData = 100

    }

    public class ApiException : Exception
    {
        public string ResponseID { get; set; }
        public int ResponseStatusCode { get; set; }
        public DateTimeOffset ResponseDateTime { get; set; }
        public string RequestMethod { get; set; }
        public string IPAddress { get; set; }
        public ErrorType Data { get; set; }
    }

    public class ErrorType
    {
        public ErrorTypeCode ErrorCode { get;  set; }
        public string ErrorCodeDescription { get;  set; }
        public string ErrorName { get;  set; }
        public string ErrorMessage { get;  set; }
        public string Message { get;  set; }
        public string Contact { get;  set; }
    }
   
}
