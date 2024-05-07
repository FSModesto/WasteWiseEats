using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(user => user.Restaurant)
                   .WithOne(restaurant => restaurant.User)
                   .HasForeignKey<Restaurant>(restaurant => restaurant.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(user => user.Employee)
                   .WithOne(employee => employee.User)
                   .HasForeignKey<Employee>(employee => employee.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(user => user.DonationCenter)
                   .WithOne(donationCenter => donationCenter.User)
                   .HasForeignKey<Employee>(donationCenter => donationCenter.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
