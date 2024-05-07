using WasteWiseEats_API.Domain.CommandHandlers.Validations.WasteRegister;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class CreateWasteRegisterCommandValidation<TResponse> : WasteRegisterCommandValidation<TResponse>
    {
        public CreateWasteRegisterCommandValidation()
        {
            ValidateFoods();
        }
    }
}