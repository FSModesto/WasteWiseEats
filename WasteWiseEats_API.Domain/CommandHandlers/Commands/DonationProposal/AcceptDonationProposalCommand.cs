using MediatR;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationProposal
{
    public class AcceptDonationProposalCommand : DonationProposalCommand<Unit>
    {
        public AcceptDonationProposalCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
