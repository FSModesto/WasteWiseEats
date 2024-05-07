using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Employee
{
    public class CreateEmployeeCommand : EmployeeCommand<Guid>
    {
        public override ValidationResult Validate()
        {
            ValidationResult = new CreateEmployeeCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
