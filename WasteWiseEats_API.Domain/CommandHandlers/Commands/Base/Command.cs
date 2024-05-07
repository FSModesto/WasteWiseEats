using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Base.Interfaces;
using WasteWiseEats_API.Domain.Exceptions;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Base
{
    public abstract class Command<T> : ICommand<T>
    {
        public Command()
        {
            ValidationResult = new();
        }

        protected ValidationResult ValidationResult { get; set; }

        public virtual ValidationResult Validate()
        {
            if (!ValidationResult.IsValid)
                throw new CommandException(GetType().Name, ValidationResult);

            return ValidationResult;
        }
    }
}
