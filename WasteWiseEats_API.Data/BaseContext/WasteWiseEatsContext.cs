using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WasteWiseEats_API.Data.Extensions;
using WasteWiseEats_API.Data.Mappings;
using WasteWiseEats_API.Domain.Entities;
using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Data.BaseContext
{
    public class WasteWiseEatsContext : DbContext
    {
        public IDbContextTransaction? Transaction { get; set; }

        public WasteWiseEatsContext(DbContextOptions<WasteWiseEatsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RestaurantMap());
            builder.ApplyConfiguration(new RestaurantAddressMap());
            builder.ApplyConfiguration(new EmployeeMap());
            builder.ApplyConfiguration(new WasteRegisterMap());
            builder.ApplyConfiguration(new FoodMap());
            builder.ApplyConfiguration(new DonationCenterMap());
            builder.ApplyConfiguration(new DonationCenterAddressMap());
            builder.ApplyConfiguration(new DonationProposalMap());
            builder.ApplyConfiguration(new UserMap());

            builder.SetDefaultConfiguration();
            builder.SetSeed();
        }
        public DbSet<Restaurant> Users { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantAddress> RestaurantAddresses { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<WasteRegister> WasteRegisters { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<DonationCenter> DonationCenters { get; set; }

        public DbSet<DonationCenterAddress> DonationCenterAddresses { get; set; }

        public DbSet<DonationProposal> DonationProposals { get; set; }

        public bool HasTransaction()
        {
            return Transaction is not null;
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            ChangeTracker.Entries().ToList().ForEach(entry =>
            {
                if (entry.Entity is Entity baseEntity)
                {
                    if (entry.State == EntityState.Added)
                        baseEntity.CreatedAt = DateTime.Now;

                    else if (entry.State == EntityState.Modified)
                        baseEntity.UpdatedAt = DateTime.Now;
                }
            });
        }
    }
}
