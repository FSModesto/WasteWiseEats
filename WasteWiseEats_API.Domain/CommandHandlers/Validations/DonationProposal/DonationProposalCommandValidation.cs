using FluentValidation;
using WasteWiseEats_API.Domain.CommandHandlers.Commands.DonationProposal;

namespace WasteWiseEats_API.Domain.CommandHandlers.Validations.DonationProposal
{
    public class DonationProposalCommandValidation<TResponse> : AbstractValidator<DonationProposalCommand<TResponse>>
    {
        protected void ValidateDonationCenter()
        {
            RuleFor(e => e.DonationCenterId)
                .NotNull()
                    .WithMessage("Campo obrigatório.");
        }

        protected void ValidateWasteRegister()
        {
            RuleFor(e => e.WasteRegisterId)
                .NotNull()
                    .WithMessage("Campo obrigatório.");
        }

        protected void ValidateRestaurant()
        {
            RuleFor(e => e.Restaurant)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(2, 256)
                    .WithMessage("Restaurante deve conter entre {MinLength} e {MaxLength} caracteres");
        }

        protected void ValidateDescription()
        {
            RuleFor(e => e.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Campo obrigatório.")
                .Length(2, 256)
                    .WithMessage("Descrição deve conter entre {MinLength} e {MaxLength} caracteres");
        }

        protected void ValidateHasAccepted()
        {
            RuleFor(e => e.HasAccepted)
                .NotNull()
                    .WithMessage("Campo obrigatório.");
        }

        protected void ValidateRemovalTime()
        {
            RuleFor(e => e.RemovalTime)
                .NotNull()
                    .WithMessage("Campo obrigatório.");
        }
    }
}
