namespace WasteWiseEats_API.Domain.Exceptions.ViewModels
{
    public class CommandExceptionViewModel : ExceptionBaseViewModel
    {
        public CommandExceptionViewModel(string traceId, CommandException commandException) : base(traceId)
        {
            Message = "Falhas de validação. Verifique os campos do formulário e tente novamente.";

            Fields = commandException.Fields;

            Notifications = commandException.Notifications;
        }

        public string Message { get; set; }

        public Dictionary<string, string> Fields { get; set; }

        public IEnumerable<string> Notifications { get; set; }
    }
}
