using WasteWiseEats_API.Domain.CommandHandlers.Validations.Employee;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class CreateEmployeeCommandValidation<TResponse> : EmployeeCommandValidation<TResponse>
    {
        public CreateEmployeeCommandValidation()
        {
            ValidateEmail();
            ValidateName();
            ValidateJob();
            ValidateDocument();
            ValidatePhone();
        }
    }
}
