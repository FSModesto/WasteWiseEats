using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public bool IsFirstAccess { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsExpired { get; set; }

        public Guid ProfileId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual DonationCenter DonationCenter { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual SecurityProfile Profile { get; set; }
    }
}