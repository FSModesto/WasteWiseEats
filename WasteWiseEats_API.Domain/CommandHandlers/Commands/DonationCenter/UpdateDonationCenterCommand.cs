using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationCenter
{
    public class UpdateDonationCenterCommand : DonationCenterCommand<Guid>
    {
        public UpdateDonationCenterCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public override ValidationResult Validate()
        {
            ValidationResult = new UpdateDonationCenterCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
