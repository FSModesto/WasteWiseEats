namespace WasteWiseEats_API.Domain.Models.Filters
{
    public class DashboardFilter
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? HasDonated { get; set; }
    }
}
