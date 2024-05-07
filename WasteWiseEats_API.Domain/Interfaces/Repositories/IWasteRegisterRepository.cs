using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Domain.Interfaces.Repositories
{
    public interface IWasteRegisterRepository : IRepository<WasteRegister>
    {
        Task<IEnumerable<WasteRegister>> GetAllByRestaurantId(Guid id);

        Task<PagedResult<WasteRegister>> GetFilteredByRestaurant(WasteRegisterFilter filter);

        Task<IEnumerable<WasteRegister>> GetForDashboard(DashboardFilter filter);
    }
}
