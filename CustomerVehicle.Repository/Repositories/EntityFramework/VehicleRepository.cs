using CustomerVehicle.Persistence.Entities;
using CustomerVehicle.Persistence.Interfaces;
using CustomerVehicle.Repository.Interfaces.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerVehicle.Repository.Repositories.EntityFramework
{
    internal class VehicleRepository : IVehicleRepository
    {
        private readonly Func<ICustomerVehicleDbContext> _customerVehicleDbContext;

        public VehicleRepository(
            Func<ICustomerVehicleDbContext> customerVehicleDbContext)
        {
            _customerVehicleDbContext = customerVehicleDbContext;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                var vehicle = await ctx.Vehicles.FindAsync(Id);

                vehicle.Deleted = true;

                return await ctx.SaveAsync();
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicle(Expression<Func<Vehicle, bool>> wherePredicate)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx
                             .Vehicles
                             .Include(x => x.Customer)
                             .Where(wherePredicate)
                             .ToListAsync();
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicle()
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx
                             .Vehicles
                             .Include(x => x.Customer)
                             .ToListAsync();
            }
        }

        public async Task<Vehicle> GetAsync(int Id)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx.Vehicles.FindAsync(Id);
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAsync()
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx.Vehicles.ToListAsync();
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAsync(Expression<Func<Vehicle, bool>> wherePredicate)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx
                             .Vehicles
                             .Where(wherePredicate)
                             .ToListAsync();
            }
        }

        public async Task<int> InsertAsync(Vehicle entity)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                await ctx.Vehicles.AddAsync(entity);

                return await ctx.SaveAsync();
            }
        }

        public async Task<bool> IsExists(Expression<Func<Vehicle, bool>> wherePredicate)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx.Vehicles.AnyAsync(wherePredicate);
            }
        }

        public async Task<int> UpdateAsync(Vehicle entity)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                ctx.AttachEntity(entity);

                ctx.SetEntityState(entity, EntityState.Modified);

                return await ctx.SaveAsync();
            }
        }
    }
}
