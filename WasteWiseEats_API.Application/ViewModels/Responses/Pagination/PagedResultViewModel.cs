namespace WasteWiseEats_API.Application.ViewModels.Responses.Pagination
{
    public class PagedResultViewModel<T>
    {
        public PagedResultViewModel()
        {
            Results = Enumerable.Empty<T>();
        }

        public int Page { get; set; }

        public int ItensPerPage { get; set; }

        public int TotalItens { get; set; }

        public int MaxPages { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}
