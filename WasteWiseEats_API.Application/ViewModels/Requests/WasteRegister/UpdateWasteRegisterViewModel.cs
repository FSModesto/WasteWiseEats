using WasteWiseEats_API.Application.ViewModels.Requests.Food;

namespace WasteWiseEats_API.Application.ViewModels.Requests.WasteRegister
{
    public class UpdateWasteRegisterViewModel
    {
        public Guid Id { get; set; }

        public ICollection<FoodRequestViewModel> Foods { get; set; }
    }
}
