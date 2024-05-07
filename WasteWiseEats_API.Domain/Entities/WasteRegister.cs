using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class WasteRegister : Entity
    {
        public Guid RestaurantId { get; set; }

        public bool HasDonated { get; set; }

        public string Employee { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual DonationProposal DonationProposal { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}