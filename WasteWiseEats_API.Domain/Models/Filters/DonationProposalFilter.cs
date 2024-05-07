namespace WasteWiseEats_API.Domain.Models.Filters
{
    public class DonationProposalFilter : PaginationFilter
    {
        public Guid DonationCenterId { get; set; }

        public string? SearchBy { get; set; }
    }
}
