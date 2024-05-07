using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Data.BaseContext;
using WasteWiseEats_API.Data.Repositories.Base;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Interfaces.Repositories;

namespace WasteWiseEats_API.Data.Repositories
{
    public class DonationCenterRepository : Repository<DonationCenter>, IDonationCenterRepository
    {
        public DonationCenterRepository(WasteWiseEatsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DonationCenter>> GetByStateAndTime(string state, TimeSpan workingTime)
        {
            return await Query(wh => wh.Address.State.Contains(state)
                      && workingTime >= wh.BeginTime
                      && workingTime <= wh.EndTime,
                      query => query.Include(i => i.Address));
        }
    }
}
