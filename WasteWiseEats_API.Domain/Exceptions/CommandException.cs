using FluentValidation.Results;

namespace WasteWiseEats_API.Domain.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException(string commandName, ValidationResult validationResult)
        {
            CommandName = commandName;

            Fields = validationResult
                .Errors.Where(validation => !string.IsNullOrEmpty(validation.PropertyName))
                       .DistinctBy(validation => validation.PropertyName)
                       .ToDictionary(failure => failure.PropertyName, failure => failure.ErrorMessage);

            Notifications = validationResult
                .Errors.Where(validation => string.IsNullOrEmpty(validation.PropertyName))
                       .Select(validation => validation.ErrorMessage); ;
        }

        public string CommandName { get; set; }

        public Dictionary<string, string> Fields { get; private set; }

        public IEnumerable<string> Notifications { get; private set; }
    }
}
