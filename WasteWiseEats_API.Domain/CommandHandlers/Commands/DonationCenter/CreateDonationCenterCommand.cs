using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationCenter
{
    public class CreateDonationCenterCommand : DonationCenterCommand<Guid>
    {
        public override ValidationResult Validate()
        {
            ValidationResult = new CreateDonationCenterCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
