using WasteWiseEats_API.Domain.CommandHandlers.Commands.Base;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Employee
{
    public abstract class EmployeeCommand<TResponse> : Command<TResponse>
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Phone { get; set; }

        public string Job { get; set; }
    }
}
