namespace WasteWiseEats_API.Application.ViewModels.Requests.Dashboard
{
    public class DashboardFilterViewModel
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? HasDonated { get; set; }
    }
}
