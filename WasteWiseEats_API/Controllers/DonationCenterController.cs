using MediatR;
using Microsoft.AspNetCore.Mvc;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.DonationCenter;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Application.ViewModels.Responses.DonationCenter;
using WasteWiseEats_API.Bases;
using WasteWiseEats_API.Domain.Attributes;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonationCenterController : BaseController
    {
        private readonly IDonationCenterAppService _appService;

        public DonationCenterController(IDonationCenterAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [RoleAuthorize(ERole.CreateDonationCenter)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateDonationCenterViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Create(viewModel);
            return Result(result);
        }

        [HttpPut]
        [RoleAuthorize(ERole.UpdateDonationCenter)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateDonationCenterViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Update(viewModel);
            return Result(result);
        }

        [HttpGet]
        [RoleAuthorize(ERole.ListDonationCenters)]
        [ProducesResponseType(typeof(ResponseViewModel<IEnumerable<GetMinifiedDonationCentersViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(string state, TimeSpan workingTime)
        {
            IResponse<IEnumerable<GetMinifiedDonationCentersViewModel>> result = await _appService.GetAll(state, workingTime);
            return Result(result);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(ERole.ReadDonationCenter)]
        [ProducesResponseType(typeof(ResponseViewModel<GetDonationCenterViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            IResponse<GetDonationCenterViewModel> result = await _appService.Get(id);
            return Result(result);
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(ERole.DeleteDonationCenter)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Result(await _appService.Delete(id));
        }
    }
}