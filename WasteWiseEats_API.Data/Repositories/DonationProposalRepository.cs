using WasteWiseEats_API.Data.BaseContext;
using WasteWiseEats_API.Data.Repositories.Base;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Pagination;
using System.Linq.Expressions;
using WasteWiseEats_API.Domain.Extensions;

namespace WasteWiseEats_API.Data.Repositories
{
    public class DonationProposalRepository : Repository<DonationProposal>, IDonationProposalRepository
    {
        public DonationProposalRepository(WasteWiseEatsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DonationProposal>> GetByDonationCenter(Guid donationCenterId)
        {
            return await Query(wh => wh.DonationCenterId == donationCenterId);
        }

        public async Task<PagedResult<DonationProposal>> GetFilteredByDonationCenter(DonationProposalFilter filter)
        {
            Expression<Func<DonationProposal, bool>> where = wh => wh.DonationCenterId == filter.DonationCenterId;

            if (!string.IsNullOrEmpty(filter.SearchBy))
                where = where.And(
                    wh => wh.Restaurant.Contains(filter.SearchBy));

            PagedResult<DonationProposal> donationProposals =
                await QueryPaged(
                    filter.Page,
                    filter.ItemsPerPage,
                    where);

            return donationProposals;
        }
    }
}