using WasteWiseEats_API.Data.BaseContext;
using WasteWiseEats_API.Data.Repositories.Base;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;

namespace WasteWiseEats_API.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WasteWiseEatsContext context) : base(context)
        {
        }
    }
}
