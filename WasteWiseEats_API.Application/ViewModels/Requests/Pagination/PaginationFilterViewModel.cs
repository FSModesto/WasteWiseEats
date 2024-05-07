namespace WasteWiseEats_API.Application.ViewModels.Requests.Pagination
{
    public abstract class PaginationFilterViewModel
    {
        public int Page { get; set; } = 1;

        public int ItemsPerPage { get; set; } = 10;
    }
}
