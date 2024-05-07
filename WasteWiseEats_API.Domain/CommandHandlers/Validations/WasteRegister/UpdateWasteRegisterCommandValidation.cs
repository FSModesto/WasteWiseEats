using WasteWiseEats_API.Domain.CommandHandlers.Validations.WasteRegister;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class UpdateWasteRegisterCommandValidation<TResponse> : WasteRegisterCommandValidation<TResponse>
    {
        public UpdateWasteRegisterCommandValidation()
        {
            ValidateFoods();
        }
    }
}