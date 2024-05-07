using WasteWiseEats_API.Domain.CommandHandlers.Validations.Employee;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class UpdateEmployeeCommandValidation<TResponse> : EmployeeCommandValidation<TResponse>
    {
        public UpdateEmployeeCommandValidation()
        {
            ValidateName();
            ValidateJob();
            ValidateDocument();
            ValidatePhone();
        }
    }
}
