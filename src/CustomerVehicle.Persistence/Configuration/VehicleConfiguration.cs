using CustomerVehicle.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerVehicle.Persistence.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.VehicleId);

            builder.HasOne(x => x.Customer).WithMany(x => x.Vehicles).HasForeignKey(x => x.CustomerId);

            builder.ApplyBaseConfigurations();
        }
    }
}
