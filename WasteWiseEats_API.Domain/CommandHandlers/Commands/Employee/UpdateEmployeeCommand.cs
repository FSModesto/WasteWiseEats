using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Employee
{
    public class UpdateEmployeeCommand : EmployeeCommand<Guid>
    {
        public UpdateEmployeeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public override ValidationResult Validate()
        {
            ValidationResult = new UpdateEmployeeCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}
