using api.evl.watch.Models;
using System.Net.Http;

namespace api.evl.watch.Utils
{
    public static class ErrorUtils
    {
        public static void SetError(ErrorType error, HttpRequestMessage request)
        {
            request.Properties["Error"] = error;
        }
        public static ErrorType GetError(HttpRequestMessage request)
        {
            if ( request.Properties.TryGetValue("Error", out object error) )
                return error as ErrorType;
            else
                return new ErrorType();
        }
    }
}