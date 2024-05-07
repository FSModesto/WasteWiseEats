namespace WasteWiseEats_API.Application.ViewModels.Responses.Address
{
    public abstract class AddressResponseViewModel
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
