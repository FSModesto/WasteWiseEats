using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class FoodMap : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasOne(food => food.WasteRegister)
                   .WithMany(wasteRegister => wasteRegister.Foods)
                   .HasForeignKey(food => food.WasteRegisterId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
