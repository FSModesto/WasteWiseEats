namespace WasteWiseEats_API.Domain.Models.Filters
{
    public class EmployeeFilter : PaginationFilter
    {
        public Guid RestaurantId { get; set; }

        public string? SearchBy { get; set; }
    }
}
