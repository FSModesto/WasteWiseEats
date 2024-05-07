namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class CreateDonationCenterCommandValidation<TResponse> : DonationCenterCommandValidation<TResponse>
    {
        public CreateDonationCenterCommandValidation()
        {
            ValidateName();
            ValidateOwner();
            ValidateOwnerDocument();
            ValidatePhone();
            ValidateEmail();
            ValidateBeginTime();
            ValidateEndTime();
            ValidateAddress();
        }
    }
}
