namespace WasteWiseEats_API.Application.ViewModels.Requests.DonationCenter
{
    public class CreateDonationCenterViewModel
    {
        public string Name { get; set; }

        public string Owner { get; set; }

        public string OwnerDocument { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TimeSpan BeginTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DonationCenterAddressRequestViewModel Address { get; set; }
    }
}
