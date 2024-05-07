namespace WasteWiseEats_API.Application.ViewModels.Responses.DonationProposal
{
    public class GetMinifiedDonationProposalsViewModel
    {
        public Guid  Id { get; set; }

        public string Restaurant { get; set; }

        public bool HasAccepted { get; set; }

        public TimeSpan RemovalTime { get; set; }
    }
}
