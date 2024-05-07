using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class Restaurant : Entity
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Owner { get; set; }

        public string OwnerDocument { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public TimeSpan DonationTime { get; set; }

        public virtual User User { get; set; }

        public virtual RestaurantAddress Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<WasteRegister> WasteRegisters { get; set; }
    }
}