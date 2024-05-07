using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class SecurityProfileRoleMap : IEntityTypeConfiguration<SecurityProfileRole>
    {
        public void Configure(EntityTypeBuilder<SecurityProfileRole> builder)
        {
            builder.HasKey(key => new
            {
                key.ProfileId,
                key.Role
            });
        }
    }
}
