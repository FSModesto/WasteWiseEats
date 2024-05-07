using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationProposal;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class CreateDonationProposalCommandValidation<TResponse> : DonationProposalCommandValidation<TResponse>
    {
        public CreateDonationProposalCommandValidation()
        {
            ValidateDonationCenter();
            ValidateWasteRegister();
            ValidateRestaurant();
            ValidateDescription();
            ValidateHasAccepted();
            ValidateRemovalTime();
        }
    }
}
