namespace WasteWiseEats_API.Application.ViewModels.Responses.Base
{
    public class ResponseViewModel
    {
        public ResponseViewModel(string traceId)
        {
            TraceId = traceId;
            At = DateTime.Now;
        }

        public string TraceId { get; }

        public DateTime At { get; set; }
    }

    public class ResponseViewModel<T> : ResponseViewModel
    {
        public ResponseViewModel(string traceId, T data) : base(traceId)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
