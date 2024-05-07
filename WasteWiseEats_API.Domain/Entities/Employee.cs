using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class Employee : Entity
    {
        public Guid UserId { get; set; }

        public Guid RestaurantId { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Phone { get; set; }

        public string Job { get; set; }

        public virtual User User { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}