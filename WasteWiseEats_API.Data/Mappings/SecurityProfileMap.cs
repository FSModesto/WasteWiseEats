using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class SecurityProfileMap : IEntityTypeConfiguration<SecurityProfile>
    {
        public void Configure(EntityTypeBuilder<SecurityProfile> builder)
        {
            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.Description)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.HasMany(e => e.Roles)
                   .WithOne(e => e.Profile)
                   .HasForeignKey(e => e.ProfileId);

            builder.HasMany(e => e.Users)
                   .WithOne(e => e.Profile)
                   .HasForeignKey(e => e.ProfileId);
        }
    }
}
