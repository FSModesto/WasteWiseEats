using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.User;
using WasteWiseEats_API.Application.ViewModels.Responses.Authentications;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Bases;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserAppService _appService;

        public UserController(IUserAppService appService)
        {
            _appService = appService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseViewModel<AuthenticatedViewModel<AuthenticatedUserViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            IResponse<AuthenticatedViewModel<AuthenticatedUserViewModel>> response =
                await _appService.Login(viewModel);

            return Result(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateUserViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Create(viewModel);
            return Result(result);
        }
    }
}