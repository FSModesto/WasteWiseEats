using Microsoft.EntityFrameworkCore;
using WasteWiseEats_API.Domain.Entities.BaseEntities;

namespace WasteWiseEats_API.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SetDefaultConfiguration(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.IsSubclassOf(typeof(Entity)))
                {
                    builder.Entity(entityType.ClrType)
                                .Property("CreatedAt")
                                .IsRequired()
                                .HasDefaultValueSql("GETDATE()");
                }
            }

            return builder;
        }
    }
}
