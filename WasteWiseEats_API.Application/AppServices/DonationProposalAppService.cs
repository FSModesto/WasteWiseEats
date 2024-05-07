using AutoMapper;
using MediatR;
using WasteWiseEats_API.Application.AppServices.Base;
using WasteWiseEats_API.Application.AppServices.Interfaces;
using WasteWiseEats_API.Application.ViewModels.Requests.DonationProposal;
using WasteWiseEats_API.Application.ViewModels.Requests.Pagination;
using WasteWiseEats_API.Application.ViewModels.Responses.DonationProposal;
using WasteWiseEats_API.Application.ViewModels.Responses.Pagination;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationProposal;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Interfaces;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Application.AppServices
{
    public class DonationProposalAppService : BaseAppService, IDonationProposalAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IDonationProposalRepository _repository;

        public DonationProposalAppService(IMediator mediator, IMapper mapper, IDonationProposalRepository repository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResponse<Guid>> Create(CreateDonationProposalViewModel viewModel)
        {
            CreateDonationProposalCommand command = _mapper.Map<CreateDonationProposalCommand>(viewModel);

            Guid id = await _mediator.Send(command);

            return Success(id);
        }

        public async Task<IResponse> Delete(Guid id)
        {
            DeleteDonationProposalCommand command = new(id);

            await _mediator.Send(command);

            return Success();
        }

        public async Task<IResponse<GetDonationProposalViewModel>> Get(Guid id)
        {
            DonationProposal donationProposal = await _repository.Get(id);

            return Success(_mapper.Map<GetDonationProposalViewModel>(donationProposal));
        }

        public async Task<IResponse<PagedResultViewModel<GetMinifiedDonationProposalsViewModel>>> GetAll(DonationProposalFilterViewModel viewModel)
        {
            DonationProposalFilter filter = _mapper.Map<DonationProposalFilter>(viewModel);

            PagedResult<DonationProposal> donationProposals = await _repository.GetFilteredByDonationCenter(filter);

            return Success(_mapper.Map<PagedResultViewModel<GetMinifiedDonationProposalsViewModel>>(donationProposals.Results.OrderByDescending(o => o.CreatedAt)));
        }

        public async Task<IResponse> Accept(Guid id)
        {
            AcceptDonationProposalCommand command = new AcceptDonationProposalCommand(id);
            
            await _mediator.Send(command);

            return Success(id);
        }
    }
}
