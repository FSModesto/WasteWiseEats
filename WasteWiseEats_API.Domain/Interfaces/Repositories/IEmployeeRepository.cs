using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Models.Filters;
using WasteWiseEats_API.Domain.Models.Pagination;

namespace WasteWiseEats_API.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<PagedResult<Employee>> GetFilteredByRestaurant(EmployeeFilter filter);
    }
}