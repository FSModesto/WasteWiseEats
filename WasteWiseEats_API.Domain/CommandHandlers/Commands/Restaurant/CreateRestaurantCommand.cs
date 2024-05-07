using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Restaurant
{
    public class CreateRestaurantCommand : RestaurantCommand<Guid>
    {
        public override ValidationResult Validate()
        {
            ValidationResult = new CreateRestaurantCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
