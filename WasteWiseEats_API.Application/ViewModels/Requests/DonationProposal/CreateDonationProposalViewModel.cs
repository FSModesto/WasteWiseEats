namespace WasteWiseEats_API.Application.ViewModels.Requests.DonationProposal
{
    public class CreateDonationProposalViewModel
    {
        public Guid DonationCenterId { get; set; }

        public Guid WasteRegisterId { get; set; }

        public string Restaurant { get; set; }

        public string Description { get; set; }

        public bool HasAccepted { get; set; }

        public TimeSpan RemovalTime { get; set; }
    }
}
