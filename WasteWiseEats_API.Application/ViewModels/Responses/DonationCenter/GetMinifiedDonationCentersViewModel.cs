namespace WasteWiseEats_API.Application.ViewModels.Responses.DonationCenter
{
    public class GetMinifiedDonationCentersViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TimeSpan BeginTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
