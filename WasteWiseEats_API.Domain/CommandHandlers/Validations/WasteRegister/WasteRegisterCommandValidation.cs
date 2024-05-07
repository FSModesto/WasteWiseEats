using FluentValidation;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.WasteRegister;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.WasteRegister
{
    public class WasteRegisterCommandValidation<TResponse> : AbstractValidator<WasteRegisterCommand<TResponse>>
    {
        protected void ValidateFoods()
        {
            RuleForEach(e => e.Foods)
                .ChildRules(foods =>
        {
            foods.RuleFor(e => e.Id)
                .NotNull()
                    .WithMessage("ID inválido.");

            foods.RuleFor(e => e.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(3, 50)
                    .WithMessage("Deve conter entre {MinLength} e {MaxLength} caracteres");

            foods.RuleFor(e => e.Quantity)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(3, 50)
                    .WithMessage("Deve conter entre {MinLength} e {MaxLength} caracteres");

            foods.RuleFor(e => e.HasPrepared)
                .NotNull()
                    .WithMessage("Campo obrigatório.");

            foods.RuleFor(e => e.IsPerishable)
                .NotNull()
                    .WithMessage("Campo obrigatório.");
        });
        }
    }
}
