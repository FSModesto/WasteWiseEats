using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class RestaurantAddressMap : IEntityTypeConfiguration<RestaurantAddress>
    {
        public void Configure(EntityTypeBuilder<RestaurantAddress> builder)
        {
        }
    }
}
