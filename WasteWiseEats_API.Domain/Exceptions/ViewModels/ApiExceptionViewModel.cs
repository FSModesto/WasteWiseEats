using WasteWiseEats_API.Domain.Exceptions.Enums;

namespace WasteWiseEats_API.Domain.Exceptions.ViewModels
{
    public class ApiExceptionViewModel : ExceptionBaseViewModel
    {
        public ApiExceptionViewModel(string traceId, string message, Enums.EApiException type) : base(traceId)
        {
            Message = message;
            ErrorId = type;
        }

        public string Message { get; set; }

        public Enums.EApiException ErrorId { get; set; }
    }
}
