using System;

namespace api.evl.watch.Models
{
    public enum ErrorTypeCode
    {
        UnhandledError = 99,
        InvalidUserRegisteringData = 100

    }
    public class ErrorType
    {
        public ErrorTypeCode ErrorCode { get; private set; }
        public string ErrorCodeDescription { get; private set; }
        public string ErrorName { get; private set; }
        public string ErrorMessage { get; private set; }
        public string Message { get; private set; }
        public string Contact { get; private set; }
        public ErrorType(string _message = "An error occurred, please try again or contact the administrator. Remember to provide your ResponseID.", string _contact = "errors@evl.watch", ErrorTypeCode _errorCode = ErrorTypeCode.UnhandledError)
        {
            ErrorCode = _errorCode;
            ErrorCodeDescription = _errorCode.ToString();
            Message = _message;
            Contact = _contact;
        }

        public void SetException(Exception exception)
        {
            ErrorMessage = exception.Message;
            ErrorName = exception.GetType().Name;
        }

    }

}