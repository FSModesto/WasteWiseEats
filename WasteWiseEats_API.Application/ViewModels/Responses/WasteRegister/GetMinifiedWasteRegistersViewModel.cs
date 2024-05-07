namespace WasteWiseEats_API.Application.ViewModels.Responses.WasteRegister
{
    public class GetMinifiedWasteRegistersViewModel
    {
        public Guid Id { get; set; }

        public bool HasDonated { get; set; }

        public string Employee { get; set; }
    }
}
