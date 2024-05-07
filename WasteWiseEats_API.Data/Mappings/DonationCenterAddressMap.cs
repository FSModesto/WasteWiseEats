using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class DonationCenterAddressMap : IEntityTypeConfiguration<DonationCenterAddress>
    {
        public void Configure(EntityTypeBuilder<DonationCenterAddress> builder)
        {
            builder.HasOne(address => address.DonationCenter)
                   .WithOne(donationCenter => donationCenter.Address)
                   .HasForeignKey<DonationCenterAddress>(address => address.DonationCenterId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
