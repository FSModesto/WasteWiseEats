namespace WasteWiseEats_API.Domain.Models.Filters
{
    public class WasteRegisterFilter : PaginationFilter
    {
        public Guid RestaurantId { get; set; }

        public string? SearchBy { get; set; }
    }
}
