namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class UpdateDonationCenterCommandValidation<TResponse> : DonationCenterCommandValidation<TResponse>
    {
        public UpdateDonationCenterCommandValidation()
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
