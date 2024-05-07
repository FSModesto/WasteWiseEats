using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class RestaurantAddress : Address
    {
        public Guid RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}