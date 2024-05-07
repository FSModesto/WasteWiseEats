using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities;

namespace WasteWiseEats_API.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(employee => employee.Restaurant)
                   .WithMany(restaurant => restaurant.Employees)
                   .HasForeignKey(employee => employee.RestaurantId);
        }
    }
}
