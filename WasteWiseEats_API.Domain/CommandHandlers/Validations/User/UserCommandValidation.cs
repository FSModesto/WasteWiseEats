using FluentValidation;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.User;
using WasteWiseEats_API.Domain.Enums;
using WasteWiseEats_API.Domain.Models;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.User
{
    public class UserCommandValidation<TResponse> : AbstractValidator<UserCommand<TResponse>>
    {
        protected void ValidateName()
        {
            RuleFor(e => e.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(3, 100)
                    .WithMessage("Deve conter entre {MinLength} e {MaxLength} caracteres");
        }

        protected void ValidateEmail()
        {
            RuleFor(e => e.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(3, 100)
                    .WithMessage("Deve conter entre {MinLength} e {MaxLength} caracteres");
        }

        protected void ValidateProfile()
        {
            RuleFor(e => e.ProfileId)
                .NotNull()
                    .WithMessage("Campo obrigatório.");
        }

        protected void ValidatePassword()
        {
            RuleFor(e => e.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Must(password => Password.HasLenght(password))
                        .WithMessage($"Deve conter no mínimo {Password.MinLenght} caracteres.")
                .Must(password => Password.HasNumber(password))
                        .WithMessage($"Deve conter números.")
                .Must(password => Password.HasUpper(password))
                        .WithMessage($"Deve conter letras maiúsculas.")
                .Must(password => Password.HasSpecialCharacter(password))
                        .WithMessage($"Deve conter caracteres especiais.");
        }

        protected void ValidatePasswordConfirmation()
        {
            RuleFor(e => e.PasswordConfirmation)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Equal(password => password.Password)
                    .WithMessage("Confirmação de senha inválida.");
        }
    }
}
