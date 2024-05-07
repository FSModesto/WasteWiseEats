using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class DonationCenterMap : IEntityTypeConfiguration<DonationCenter>
    {
        public void Configure(EntityTypeBuilder<DonationCenter> builder)
        {
            builder.HasMany(donationCenter => donationCenter.DonationProposals)
                   .WithOne(donationProposal => donationProposal.DonationCenter)
                   .HasForeignKey(donationProposal => donationProposal.DonationCenterId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
