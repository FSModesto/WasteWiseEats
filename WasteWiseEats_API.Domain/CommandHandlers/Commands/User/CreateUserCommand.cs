using FluentValidation.Results;
using WasteWiseEats_API.Domain.CommandHandlers.Validations.User;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.User
{
    public class CreateUserCommand : UserCommand<Guid>
    {
        public override ValidationResult Validate()
        {
            ValidationResult = new CreateUserCommandValidation<Guid>().Validate(this);

            return base.Validate();
        }
    }
}