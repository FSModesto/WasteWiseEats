using Microsoft.AspNetCore.Mvc;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Bases
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Result(IResponse response)
        {
            return StatusCode((int)response.StatusCode, new ResponseViewModel(HttpContext.TraceIdentifier));
        }

        protected IActionResult Result<T>(IResponse<T> response)
        {
            return StatusCode((int)response.StatusCode, new ResponseViewModel<T>(HttpContext.TraceIdentifier, response.Data));
        }
    }
}
