using WasteWiseEats_API.Domain.CommandHandlers.Validations.Restaurant;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class CreateRestaurantCommandValidation<TResponse> : RestaurantCommandValidation<TResponse>
    {
        public CreateRestaurantCommandValidation()
        {
            ValidateName();
            ValidateDocument();
            ValidateOwner();
            ValidateOwnerDocument();
            ValidatePhone();
            ValidateEmail();
            ValidateDonationTime();
            ValidateAddress();

        }
    }
}
