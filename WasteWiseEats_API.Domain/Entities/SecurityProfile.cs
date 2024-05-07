using System.Collections.ObjectModel;
using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Domain.Entities
{
    public class SecurityProfile : Entity
    {
        public static readonly Guid SUPER_USER_ID = new("3f92d673-3abe-4ee5-9e7a-ed927918ed31");
        public static readonly Guid DONATION_CENTER_OWNER_ID = new("100f0e52-f543-4586-bc1e-f2741f56b535");
        public static readonly Guid RESTAURANT_OWNER_ID = new("361a6151-97ee-470e-b901-6c9160b974a9");
        public static readonly Guid RESTAURANT_ATENDANT_ID = new("cc0be4a1-a29d-43d8-97d9-0151015a4147");

        public SecurityProfile()
        {
            Roles = new Collection<SecurityProfileRole>();
            Users = new Collection<User>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SecurityProfileRole> Roles { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
