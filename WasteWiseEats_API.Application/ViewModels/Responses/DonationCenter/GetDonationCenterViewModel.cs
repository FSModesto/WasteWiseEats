namespace WasteWiseEats_API.Application.ViewModels.Responses.DonationCenter
{
    public class GetDonationCenterViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string OwnerDocument { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TimeSpan BeginTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public DonationCenterAddressResponseViewModel Address { get; set; }
    }
}
