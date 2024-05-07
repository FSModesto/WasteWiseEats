namespace WasteWiseEats_API.Application.ViewModels.Responses.DonationProposal
{
    public class GetDonationProposalViewModel
    {
        public Guid  Id { get; set; }

        public string Restaurant { get; set; }

        public string Description { get; set; }

        public bool HasAccepted { get; set; }

        public TimeSpan RemovalTime { get; set; }
    }
}
