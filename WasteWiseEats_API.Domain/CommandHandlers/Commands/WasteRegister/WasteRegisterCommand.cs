using MediatR;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Base;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister
{
    public abstract class WasteRegisterCommand<TResponse> : Command<TResponse>
    {
        public ICollection<FoodSubCommand> Foods { get; set; }
    }
}
