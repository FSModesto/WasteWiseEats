using System.Net;

namespace WasteWiseEats_API.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StatusCodeErrorAttribute : Attribute
    {
        public StatusCodeErrorAttribute(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}
