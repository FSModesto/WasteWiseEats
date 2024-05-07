namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.User
{
    public class CreateUserCommandValidation<TResponse> : UserCommandValidation<TResponse>
    {
        public CreateUserCommandValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateProfile();
            ValidatePassword();
            ValidatePasswordConfirmation();
        }
    }
}
