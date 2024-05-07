using WasteWiseEats_API.Application.ViewModels.Requests.Food;

namespace WasteWiseEats_API.Application.ViewModels.Requests.WasteRegister
{
    public class CreateWasteRegisterViewModel
    {
        public ICollection<FoodRequestViewModel> Foods { get; set; }
    }
}
