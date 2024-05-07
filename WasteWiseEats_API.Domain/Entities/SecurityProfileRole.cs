using WasteWiseEats_API.Domain.Enums;

namespace WasteWiseEats_API.Domain.Entities
{
    public class SecurityProfileRole
    {
        public ERole Role { get; set; }

        public Guid ProfileId { get; set; }

        public virtual SecurityProfile Profile { get; set; }
    }
}
