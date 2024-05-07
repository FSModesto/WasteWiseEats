using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationProposal
{
    public class CreateDonationProposalCommand : DonationProposalCommand<Guid>
    {
        public override ValidationResult Validate()
        {
            ValidationResult = new CreateDonationProposalCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
