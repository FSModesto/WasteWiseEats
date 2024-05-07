using System.Net;
using WasteWiseEats_API.Domain.Models;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Application.AppServices.Base
{
    public class BaseAppService
    {
        protected IResponse Success(HttpStatusCode? statusCode = null)
        {
            return new Response(statusCode);
        }

        protected IResponse<T> Success<T>(T data, HttpStatusCode? statusCode = null)
        {
            return new Result<T>(data, statusCode);
        }
    }
}
