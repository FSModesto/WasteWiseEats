

using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister
{
    public class CreateWasteRegisterCommand : WasteRegisterCommand<Guid>
    {
        public override ValidationResult Validate()
        {
            ValidationResult = new CreateWasteRegisterCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
