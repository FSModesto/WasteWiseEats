using Microsoft.AspNetCore.Mvc;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.Dashboard;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Application.ViewModels.Responses.Dashboard;
using WasteWiseEats_API.Bases;
using WasteWiseEats_API.Domain.Attributes;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : BaseController
    {
        private readonly IDashboardAppService _appService;

        public DashboardController(IDashboardAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        [RoleAuthorize(ERole.ReadDashboards)]
        [ProducesResponseType(typeof(ResponseViewModel<IEnumerable<DashboardResponseViewModel>>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Get(DashboardFilterViewModel viewModel)
        {
            IResponse<IEnumerable<DashboardResponseViewModel>> result = await _appService.Get(viewModel);
            return Result(result);
        }
    }
}