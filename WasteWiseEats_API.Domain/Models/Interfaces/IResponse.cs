using System.Net;

namespace WasteWiseEats_API.Domain.Models.Interfaces
{
    public interface IResponse
    {
        public HttpStatusCode StatusCode { get; set; }
    }

    public interface IResponse<T> : IResponse
    {
        public T Data { get; set; }
    }
}
