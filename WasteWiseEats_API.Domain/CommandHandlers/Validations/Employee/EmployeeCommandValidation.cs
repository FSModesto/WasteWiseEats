using FluentValidation;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.Employee;
using WasteWiseEats_API.Domain.Models;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.Employee
{
    public class EmployeeCommandValidation<TResponse> : AbstractValidator<EmployeeCommand<TResponse>>
    {
        protected void ValidateEmail()
        {
            RuleFor(e => e.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(3, 100)
                    .WithMessage("Deve conter entre {MinLength} e {MaxLength} caracteres");
        }

        protected void ValidateName()
        {
            RuleFor(e => e.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(3, 100)
                    .WithMessage("Deve conter entre {MinLength} e {MaxLength} caracteres");
        }

        protected void ValidateJob()
        {
            RuleFor(e => e.Job)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(3, 50)
                    .WithMessage("Deve conter entre {MinLength} e {MaxLength} caracteres");
        }

        protected void ValidateDocument()
        {
            RuleFor(e => e.Document)
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
    }
}
