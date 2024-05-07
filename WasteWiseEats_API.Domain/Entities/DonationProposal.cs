using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class DonationProposal : Entity
    {
        public Guid DonationCenterId { get; set; }

        public Guid WasteRegisterId { get; set; }

        public string Restaurant { get; set; }

        public string Description { get; set; }

        public bool HasAccepted { get; set; }

        public TimeSpan RemovalTime { get; set; }

        public virtual DonationCenter DonationCenter { get; set; }

        public virtual WasteRegister WasteRegister { get; set; }
    }
}