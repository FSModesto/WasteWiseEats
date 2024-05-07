using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class WasteRegisterMap : IEntityTypeConfiguration<WasteRegister>
    {
        public void Configure(EntityTypeBuilder<WasteRegister> builder)
        {
            builder.HasOne(wasteRegister => wasteRegister.Restaurant)
                   .WithMany(restaurant => restaurant.WasteRegisters)
                   .HasForeignKey(wasteRegister => wasteRegister.RestaurantId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
