using Microsoft.AspNetCore.Mvc;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.Employee;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Application.ViewModels.Responses.Employee;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Bases;
using WasteWiseEats_API.Domain.Attributes;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController
    {

        private readonly IEmployeeAppService _appService;

        public EmployeeController(IEmployeeAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [RoleAuthorize(ERole.CreateEmployee)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateEmployeeViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Create(viewModel);
            return Result(result);
        }

        [HttpPut]
        [RoleAuthorize(ERole.UpdateEmployee)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateEmployeeViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Update(viewModel);
            return Result(result);
        }

        [HttpGet]
        [RoleAuthorize(ERole.ListEmployees)]
        [ProducesResponseType(typeof(ResponseViewModel<PagedResultViewModel<GetMinifiedEmployeesViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] EmployeeFilterViewModel viewModel)
        {
            IResponse<PagedResultViewModel<GetMinifiedEmployeesViewModel>> result = await _appService.GetAll(viewModel);
            return Result(result);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(ERole.ReadEmployee)]
        [ProducesResponseType(typeof(ResponseViewModel<GetEmployeeViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            IResponse<GetEmployeeViewModel> result = await _appService.Get(id);
            return Result(result);
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(ERole.DeleteEmployee)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            IResponse result = await _appService.Delete(id);
            return Result(result);
        }
    }
}