using CustomerVehicle.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Persistence.Interfaces
{
    public interface ICustomerVehicleDbContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }

        void SetEntityState(EntityBase entity, EntityState state);
        void AttachEntity(EntityBase entity);
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
