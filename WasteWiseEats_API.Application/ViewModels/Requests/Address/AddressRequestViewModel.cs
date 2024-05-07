namespace WasteWiseEats_API.Application.ViewModels.Requests.Address
{
    public abstract class AddressRequestViewModel
    {
        public Guid Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
