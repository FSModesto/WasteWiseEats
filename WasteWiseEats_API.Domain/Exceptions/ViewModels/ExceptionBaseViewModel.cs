namespace WasteWiseEats_API.Domain.Exceptions.ViewModels
{
    public abstract class ExceptionBaseViewModel
    {
        public ExceptionBaseViewModel(string traceId)
        {
            TraceId = traceId;
            At = DateTime.Now;
        }
        public string TraceId { get; }

        public DateTime At { get; }
    }
}
