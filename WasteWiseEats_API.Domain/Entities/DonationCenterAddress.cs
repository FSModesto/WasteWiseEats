using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class DonationCenterAddress : Address
    {
        public Guid DonationCenterId { get; set; }

        public virtual DonationCenter DonationCenter { get; set; }
    }
}