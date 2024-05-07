

using MediatR;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister
{
    public class WasteRegisterFeedbackCommand : WasteRegisterCommand<Unit>
    {
        public WasteRegisterFeedbackCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
