using MediatR;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationProposal;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Exceptions;
using WasteWiseEats_API.Domain.Exceptions.Enums;
using WasteWiseEats_API.Domain.Interfaces.Repositories;

namespace WasteWiseEats_API.Domain.CommandHandlers
{
    public class DonationProposalCommandHandler : IRequestHandler<CreateDonationProposalCommand, Guid>,
                                            IRequestHandler<AcceptDonationProposalCommand, Unit>,
                                            IRequestHandler<DeleteDonationProposalCommand, Unit>
    {
        private readonly IDonationProposalRepository _repository;
        private readonly IMediator _mediator;

        public DonationProposalCommandHandler(IDonationProposalRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateDonationProposalCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.Exists(wh => wh.WasteRegisterId == request.WasteRegisterId))
                throw new ApiException(EApiException.DonationProposalAlreadyExists);

            DonationProposal donationProposal = new()
            {
                DonationCenterId = request.DonationCenterId,
                WasteRegisterId = request.WasteRegisterId,
                Restaurant = request.Restaurant,
                Description = request.Description,
                HasAccepted = false,
                RemovalTime = request.RemovalTime
            };

            await _repository.Create(donationProposal);
            return donationProposal.Id;
        }

        public async Task<Unit> Handle(AcceptDonationProposalCommand request, CancellationToken cancellationToken)
        {
            DonationProposal donationProposal = await ValidateDonationProposal(request.Id);

            donationProposal.HasAccepted = true;

            await _repository.Update(donationProposal);

            WasteRegisterFeedbackCommand command = new(donationProposal.WasteRegisterId);

            await _mediator.Send(command);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteDonationProposalCommand request, CancellationToken cancellationToken)
        {
            DonationProposal donationProposal = await ValidateDonationProposal(request.Id);

            if (donationProposal.HasAccepted)
                throw new ApiException(EApiException.DonationProposalAccepted);

            await _repository.Delete(donationProposal);

            return Unit.Value;
        }

        private async Task<DonationProposal> ValidateDonationProposal(Guid id)
        {
            DonationProposal donationProposal = await _repository.Get(id);

            if (donationProposal is null)
                throw new ApiException(EApiException.DonationProposalNotFound);

            return donationProposal;
        }
    }
}
