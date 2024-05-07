using Microsoft.AspNetCore.Mvc;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.DonationProposal;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.Base;
using WasteWiseEats_API.Application.ViewModels.Responses.DonationProposal;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Bases;
using WasteWiseEats_API.Domain.Attributes;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Models.Interfaces;

namespace WasteWiseEats_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonationProposalController : BaseController
    {
        private readonly IDonationProposalAppService _appService;

        public DonationProposalController(IDonationProposalAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [RoleAuthorize(ERole.CreateDonationProposal)]
        [ProducesResponseType(typeof(ResponseViewModel<Guid>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateDonationProposalViewModel viewModel)
        {
            IResponse<Guid> result = await _appService.Create(viewModel);
            return Result(result);
        }

        [HttpPut]
        [RoleAuthorize(ERole.AcceptDonationProposal)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Accept(Guid id)
        {
            return Result(await _appService.Accept(id));
        }

        [HttpGet]
        [RoleAuthorize(ERole.ListDonationProposals)]
        [ProducesResponseType(typeof(ResponseViewModel<PagedResultViewModel<GetMinifiedDonationProposalsViewModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] DonationProposalFilterViewModel viewModel)
        {
            IResponse<PagedResultViewModel<GetMinifiedDonationProposalsViewModel>> result = await _appService.GetAll(viewModel);
            return Result(result);
        }

        [HttpGet("{id}")]
        [RoleAuthorize(ERole.ReadDonationProposal)]
        [ProducesResponseType(typeof(ResponseViewModel<GetDonationProposalViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            IResponse<GetDonationProposalViewModel> result = await _appService.Get(id);
            return Result(result);
        }

        [HttpDelete("{id}")]
        [RoleAuthorize(ERole.DeleteDonationProposal)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Result(await _appService.Delete(id));
        }
    }
}