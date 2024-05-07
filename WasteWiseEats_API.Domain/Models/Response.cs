using System.Net;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Domain.Models
{
    public class Response : IResponse
    {
        public Response(HttpStatusCode? statusCode = null)
        {
            StatusCode = statusCode ?? HttpStatusCode.OK;
        }

        public HttpStatusCode StatusCode { get; set; }
    }

    public class Result<T> : Response, IResponse<T>
    {
        public Result(T data, HttpStatusCode? statusCode = null) : base(statusCode)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
