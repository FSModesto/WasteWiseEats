using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class DonationProposalMap : IEntityTypeConfiguration<DonationProposal>
    {
        public void Configure(EntityTypeBuilder<DonationProposal> builder)
        {
            builder.HasOne(donationProposal => donationProposal.WasteRegister)
                   .WithOne(WasteRegister => WasteRegister.DonationProposal)
                   .HasForeignKey<DonationProposal>(donationProposal => donationProposal.WasteRegisterId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
