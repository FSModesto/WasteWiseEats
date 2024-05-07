using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Domain.Interfaces.Repositories
{
    public interface IDonationCenterRepository : IRepository<DonationCenter>
    {
        Task<IEnumerable<DonationCenter>> GetByStateAndTime(string state, TimeSpan workingTime);
    }
}
