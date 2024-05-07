namespace WasteWiseEats_API.Application.ViewModels.Requests.Pagination
{
    public class DonationProposalFilterViewModel : PaginationFilterViewModel
    {
        public Guid DonationCenterId { get; set; }

        public string? SearchBy { get; set; }
    }
}
