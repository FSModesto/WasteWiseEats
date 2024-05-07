using WasteWiseEats_API.Application.ViewModels.Responses.Food;

namespace WasteWiseEats_API.Application.ViewModels.Responses.WasteRegister
{
    public class GetWasteRegisterViewModel
    {
        public Guid Id { get; set; }

        public bool HasDonated { get; set; }

        public string Employee { get; set; }

        public IEnumerable<FoodResponseViewModel> Foods { get; set; }
    }
}
