namespace WasteWiseEats_API.Application.ViewModels.Requests.Pagination
{
    public class EmployeeFilterViewModel : PaginationFilterViewModel
    {
        public Guid RestaurantId { get; set; }

        public string? SearchBy { get; set; }
    }
}
