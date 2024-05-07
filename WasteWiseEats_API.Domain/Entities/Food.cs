using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class Food : Entity
    {
        public Guid WasteRegisterId { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public bool IsPerishable { get; set; }

        public bool HasPrepared { get; set; }

        public virtual WasteRegister WasteRegister { get; set; }
    }
}