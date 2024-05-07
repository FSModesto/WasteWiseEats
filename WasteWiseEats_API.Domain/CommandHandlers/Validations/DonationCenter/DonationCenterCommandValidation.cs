using FluentValidation;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationCenter;
using WasteWiseEats_API.Domain.Models;
using Document = WasteWiseEats_API.Domain.Models.Document;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationCenter
{
    public class DonationCenterCommandValidation<TResponse> : AbstractValidator<DonationCenterCommand<TResponse>>
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

        protected void ValidateBeginTime()
        {
            RuleFor(e => e.BeginTime)
                .NotNull()
                    .WithMessage("Campo obrigatório.");
        }

        protected void ValidateEndTime()
        {
            RuleFor(e => e.EndTime)
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
