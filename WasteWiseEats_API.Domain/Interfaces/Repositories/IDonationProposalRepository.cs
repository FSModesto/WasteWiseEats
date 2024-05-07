using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Domain.Interfaces.Repositories
{
    public interface IDonationProposalRepository : IRepository<DonationProposal>
    {
        Task<IEnumerable<DonationProposal>> GetByDonationCenter(Guid donationCenterId);

        Task<PagedResult<DonationProposal>> GetFilteredByDonationCenter(DonationProposalFilter filter);
    }
}
