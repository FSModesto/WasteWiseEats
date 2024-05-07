using WasteWiseEats_API.Domain.Extensions;

namespace WasteWiseEats_API.Domain.Exceptions.ViewModels
{
    public class ExceptionViewModel : ExceptionBaseViewModel
    {
        public ExceptionViewModel(Exception exception, string messagePrefix, string traceId) : base(traceId)
        {
            Message = messagePrefix;

            if (!EnvironmentHelper.IsProduction())
            {
                Message += $" - {exception.Message}";

                if (exception.InnerException is not null)
                    Message += $" - InnerException: {exception.InnerException.Message}";
            }
        }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
