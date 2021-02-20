using CustomerVehicle.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerVehicle.Persistence.Configuration
{
    public static class EntityConfigurationExtension
    {
        public static void ApplyBaseConfigurations<T>(this EntityTypeBuilder<T> builder) where T : EntityBase
        {
            builder.HasQueryFilter(x => x.Deleted == false);
        }
    }
}
