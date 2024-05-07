using FluentValidation;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Restaurant;
using WasteWiseEats_API.Domain.Models;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.Restaurant
{
    public class RestaurantCommandValidation<TResponse> : AbstractValidator<RestaurantCommand<TResponse>>
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

        protected void ValidateDocument()
        {
            RuleFor(e => e.Document)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Must(cpf => Document.IsCNPJ(cpf))
                    .WithMessage("CNPJ inválido");
        }

        protected void ValidateOwner()
        {
            RuleFor(e => e.Owner)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(3, 50)
                    .WithMessage("Deve conter entre {MinLength} e {MaxLength} caracteres");
        }

        protected void ValidateOwnerDocument()
        {
            RuleFor(e => e.OwnerDocument)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Must(cpf => Document.IsCPF(cpf))
                    .WithMessage("CPF inválido");
        }

        protected void ValidatePhone()
        {
            RuleFor(e => e.Phone)
                .NotNull()
                    .WithMessage("Campo obrigatório.")
                .Must(phone => Phone.IsValidDDD(phone))
                    .WithMessage("DDD inválido")
                .Must(phone => Phone.IsValidPhoneNumber(phone))
                    .WithMessage("Telefone inválido");
        }

        protected void ValidateEmail()
        {
            RuleFor(e => e.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório")
                .Length(2, 256)
                    .WithMessage("Email deve conter entre {MinLength} e {MaxLength} caracteres")
                .EmailAddress()
                    .WithMessage("Email inválido");
        }

        protected void ValidateDonationTime()
        {
            RuleFor(e => e.DonationTime)
                .NotNull()
                    .WithMessage("Campo obrigatório.");
        }


        protected void ValidateAddress()
        {
            RuleFor(e => e.Address.Street)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.");

            RuleFor(e => e.Address.ZipCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Must(cep => Cep.IsCEP(cep))
                    .WithMessage("Valor inválido.");

            RuleFor(e => e.Address.Number)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.");

            RuleFor(e => e.Address.District)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.");

            RuleFor(e => e.Address.City)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.");

            RuleFor(e => e.Address.State)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Must(state => State.IsValidState(state))
                    .WithMessage("Valor inválido.");
        }
    }
}
