using WasteWiseEats_API.Domain.CommandHandlers.Commands.Base;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationProposal
{
    public abstract class DonationProposalCommand<TResponse> : Command<TResponse>
    {
        public Guid DonationCenterId { get; set; }

        public Guid WasteRegisterId { get; set; }

        public string Restaurant { get; set; }

        public string Description { get; set; }

        public bool HasAccepted { get; set; }

        public TimeSpan RemovalTime { get; set; }
    }
}
