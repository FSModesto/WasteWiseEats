using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Restaurant
{
    public class UpdateRestaurantCommand : RestaurantCommand<Guid>
    {
        public UpdateRestaurantCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public override ValidationResult Validate()
        {
            ValidationResult = new UpdateRestaurantCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
