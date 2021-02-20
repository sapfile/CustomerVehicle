using CustomerVehicle.Infrastructure.Interfaces;
using CustomerVehicle.Persistence.Entities;
using CustomerVehicle.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Persistence.Context
{
    internal class CustomerVehicleDbContext : DbContext, ICustomerVehicleDbContext
    {
        private readonly IDateTime _dateTime;
        public CustomerVehicleDbContext(
            DbContextOptions<CustomerVehicleDbContext> options,
            IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), x => x.Name.Contains("Configuration"));

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            var entry = ChangeTracker.Entries<EntityBase>().FirstOrDefault(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            if (entry != null)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.InsertedDate = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public void SetEntityState(EntityBase entity, EntityState state)
        {
            base.Entry(entity).State = state;
        }

        public void AttachEntity(EntityBase entity)
        {
            base.Attach(entity);
        }
    }
}
