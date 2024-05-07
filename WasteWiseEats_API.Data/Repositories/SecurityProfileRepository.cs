using WasteWiseEats_API.Data.BaseContext;
using WasteWiseEats_API.Data.Repositories.Base;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;

namespace WasteWiseEats_API.Data.Repositories
{
    public class SecurityProfileRepository : Repository<SecurityProfile>, ISecurityProfileRepository
    {
        public SecurityProfileRepository(WasteWiseEatsContext context) : base(context)
        {
        }
    }
}