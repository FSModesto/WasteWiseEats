using Microsoft.AspNetCore.Mvc;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.Restaurant;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Application.ViewModels.Responses.Restaurant;
using WasteWiseEats_API.Bases;
using WasteWiseEats_API.Domain.Attributes;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantAppService _appService;

        public RestaurantController(IRestaurantAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [RoleAuthorize(ERole.CreateRestaurant)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateRestaurantViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Create(viewModel);
            return Result(result);
        }

        [HttpPut]
        [RoleAuthorize(ERole.UpdateRestaurant)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateRestaurantViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Update(viewModel);
            return Result(result);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(ERole.ReadRestaurant)]
        [ProducesResponseType(typeof(ResponseViewModel<GetRestaurantViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            IResponse<GetRestaurantViewModel> result = await _appService.Get(id);
            return Result(result);
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(ERole.DeleteRestaurant)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Result(await _appService.Delete(id));
        }
    }
}