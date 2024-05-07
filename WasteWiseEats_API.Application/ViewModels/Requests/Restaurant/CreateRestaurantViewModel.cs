namespace WasteWiseEats_API.Application.ViewModels.Requests.Restaurant
{
    public class CreateRestaurantViewModel
    {
        public string Name { get; set; }

        public string Document { get; set; }

        public string Owner { get; set; }

        public string OwnerDocument { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TimeSpan DonationTime { get; set; }

        public RestaurantAddressRequestViewModel Address { get; set; }
    }
}
