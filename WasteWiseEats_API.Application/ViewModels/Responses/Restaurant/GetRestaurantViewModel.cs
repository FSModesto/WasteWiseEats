namespace WasteWiseEats_API.Application.ViewModels.Responses.Restaurant
{
    public class GetRestaurantViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Owner { get; set; }

        public string OwnerDocument { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TimeSpan DonationTime { get; set; }

        public GetRestaurantAddressViewModel Address { get; set; }
    }
}
