namespace WasteWiseEats_API.Application.ViewModels.Requests.Pagination
{
    public class WasteRegisterFilterViewModel : PaginationFilterViewModel
    {
        public Guid RestaurantId { get; set; }

        public string? SearchBy { get; set; }
    }
}
