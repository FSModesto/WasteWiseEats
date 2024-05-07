using MediatR;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister
{
    public class DeleteWasteRegisterCommand : WasteRegisterCommand<Unit>
    {
        public DeleteWasteRegisterCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
