using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class RestaurantMap : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasOne(restaurant => restaurant.Address)
                   .WithOne(address => address.Restaurant)
                   .HasForeignKey<RestaurantAddress>(address => address.RestaurantId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
