using FluentValidation.Results;

namespace WasteWiseEats_API.Domain.Extensions
{
    public static class ValidationExtension
    {
        public static void AddError(this ValidationResult validation, string error, string key = null)
        {
            validation.Errors.Add(new ValidationFailure(key, error));
        }
    }
}
