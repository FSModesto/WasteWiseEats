using Microsoft.AspNetCore.Mvc;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Requests.WasteRegister;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.Restaurant;
using WasteWiseEats_API.Application.ViewModels.Responses.WasteRegister;
using WasteWiseEats_API.Bases;
using WasteWiseEats_API.Domain.Attributes;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WasteRegisterController : BaseController
    {
        private readonly IWasteRegisterAppService _appService;

        public WasteRegisterController(IWasteRegisterAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [RoleAuthorize(ERole.CreateWasteRegister)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateWasteRegisterViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Create(viewModel);
            return Result(result);
        }

        [HttpPut]
        [RoleAuthorize(ERole.UpdateWasteRegister)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateWasteRegisterViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Update(viewModel);
            return Result(result);
        }

        [HttpGet]
        [RoleAuthorize(ERole.ListWasteRegisters)]
        [ProducesResponseType(typeof(ResponseViewModel<PagedResultViewModel<GetMinifiedWasteRegistersViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] WasteRegisterFilterViewModel viewModel)
        {
            IResponse<PagedResultViewModel<GetMinifiedWasteRegistersViewModel>> result = await _appService.GetAll(viewModel);
            return Result(result);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(ERole.ReadWasteRegister)]
        [ProducesResponseType(typeof(ResponseViewModel<GetRestaurantViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            IResponse<GetWasteRegisterViewModel> result = await _appService.Get(id);
            return Result(result);
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(ERole.DeleteWasteRegister)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Result(await _appService.Delete(id));
        }
    }
}