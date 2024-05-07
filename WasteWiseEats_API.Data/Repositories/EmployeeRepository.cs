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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(WasteWiseEatsContext context) : base(context)
        {
        }

        public async Task<PagedResult<Employee>> GetFilteredByRestaurant(EmployeeFilter filter)
        {
            Expression<Func<Employee, bool>> where = wh => wh.RestaurantId == filter.RestaurantId;

            if (!string.IsNullOrEmpty(filter.SearchBy))
                where = where.And(
                    wh => wh.Name.Contains(filter.SearchBy)
                       || wh.Document.Contains(filter.SearchBy));

            PagedResult<Employee> employees =
                await QueryPaged(
                    filter.Page,
                    filter.ItemsPerPage,
                    where);

            return employees;
        }
    }
}
