using System.Net;
using WasteWiseEats_API.Domain.Attributes;
using WasteWiseEats_API.Domain.Extensions;

namespace WasteWiseEats_API.Domain.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message)
        {
            Type = Enums.EApiException.Generic;
            StatusCode = statusCode;
        }

        public ApiException(Enums.EApiException apiException) : base(GetApiExceptionMessage(apiException))
        {
            StatusCodeErrorAttribute statusCodeError = GetStatusCodeError(apiException);

            Type = apiException;
            StatusCode = statusCodeError.StatusCode;
        }

        public ApiException(Enums.EApiException apiException, string message, HttpStatusCode? statusCode = null) : base(GetApiExceptionMessage(apiException, message))
        {
            StatusCodeErrorAttribute statusCodeError = GetStatusCodeError(apiException);

            Type = apiException;
            StatusCode = statusCode ?? statusCodeError.StatusCode;
        }

        public Enums.EApiException Type { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public override string StackTrace { get => null; }

        private static string GetApiExceptionMessage(Enums.EApiException apiException, string message = "")
        {
            StatusCodeErrorAttribute statusCodeError = GetStatusCodeError(apiException);

            string _message = statusCodeError.Message;

            if (!string.IsNullOrEmpty(message))
                _message += $" | {message}";

            return _message;
        }

        private static StatusCodeErrorAttribute GetStatusCodeError(Enums.EApiException apiException)
        {
            return apiException.GetEnumAttribute<Enums.EApiException, StatusCodeErrorAttribute>();
        }
    }
}
