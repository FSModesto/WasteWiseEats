using FluentValidation.Results;
using MediatR;

namespace WasteWiseEats_API.Domain.CommandHandlers.Commands.Base.Interfaces
{
    public interface ICommand<T> : IRequest<T>
    {
        ValidationResult Validate();
    }
}
