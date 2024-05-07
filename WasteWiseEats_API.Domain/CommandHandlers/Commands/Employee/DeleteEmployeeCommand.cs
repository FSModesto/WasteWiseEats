using MediatR;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Employee
{
    public class DeleteEmployeeCommand : EmployeeCommand<Unit>
    {
        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
