using WasteWiseEats_API.Domain.CommandHandlers.Validations.Restaurant;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class UpdateRestaurantCommandValidation<TResponse> : RestaurantCommandValidation<TResponse>
    {
        public UpdateRestaurantCommandValidation()
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
