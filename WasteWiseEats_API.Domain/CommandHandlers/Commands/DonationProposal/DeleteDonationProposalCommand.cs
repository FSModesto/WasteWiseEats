using MediatR;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationProposal
{
    public class DeleteDonationProposalCommand : DonationProposalCommand<Unit>
    {
        public DeleteDonationProposalCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
