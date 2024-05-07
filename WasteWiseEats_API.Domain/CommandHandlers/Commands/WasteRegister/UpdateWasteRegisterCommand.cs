using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister
{
    public class UpdateWasteRegisterCommand : WasteRegisterCommand<Guid>
    {
        public UpdateWasteRegisterCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public override ValidationResult Validate()
        {
            ValidationResult = new UpdateWasteRegisterCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
