using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class DonationCenter : Entity
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public string OwnerDocument { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TimeSpan BeginTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public virtual User User { get; set; }

        public virtual DonationCenterAddress Address { get; set; }

        public virtual ICollection<DonationProposal> DonationProposals { get; set; }
    }
}