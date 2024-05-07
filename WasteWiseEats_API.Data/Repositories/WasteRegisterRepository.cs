using System.Linq.Expressions;
using WasteWiseEats_API.Data.BaseContext;
using WasteWiseEats_API.Data.Repositories.Base;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Extensions;
using WasteWiseEats_API.Domain.Interfaces.Repositories;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Data.Repositories
{
    public class WasteRegisterRepository : Repository<WasteRegister>, IWasteRegisterRepository
    {
        public WasteRegisterRepository(WasteWiseEatsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WasteRegister>> GetAllByRestaurantId(Guid id)
        {
            return await Query(wh =>wh.RestaurantId == id);
        }

        public async Task<PagedResult<WasteRegister>> GetFilteredByRestaurant(WasteRegisterFilter filter)
        {
            Expression<Func<WasteRegister, bool>> where = wh => wh.RestaurantId == filter.RestaurantId;

            if (!string.IsNullOrEmpty(filter.SearchBy))
                where = where.And(
                    wh => wh.Employee.Contains(filter.SearchBy));

            PagedResult<WasteRegister> wasteRegisters =
                await QueryPaged(
                    filter.Page,
                    filter.ItemsPerPage,
                    where);

            return wasteRegisters;
        }

        public async Task<IEnumerable<WasteRegister>> GetForDashboard(DashboardFilter filter)
        {
            Expression<Func<WasteRegister, bool>> where = wh => true;

            if (filter.StartDate.HasValue)
                where = where.And(wh => wh.CreatedAt >= filter.StartDate.Value);
            

            if (filter.EndDate.HasValue)
                where = where.And(wh => wh.CreatedAt <= filter.EndDate.Value);
            
            where = where.And(wh => wh.HasDonated);

            return await Query(where);
        }
    }
}
