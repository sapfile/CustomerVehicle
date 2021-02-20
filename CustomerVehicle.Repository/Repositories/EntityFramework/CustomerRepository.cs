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
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly Func<ICustomerVehicleDbContext> _customerVehicleDbContext;

        public CustomerRepository(
            Func<ICustomerVehicleDbContext> customerVehicleDbContext)
        {
            _customerVehicleDbContext = customerVehicleDbContext;
        }

        public async Task<int> BulkInsert(IEnumerable<Customer> data)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                await ctx.Customers.AddRangeAsync(data);

                return await ctx.SaveAsync();
            }
        }

        public async Task<Customer> GetAsync(int Id)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx.Customers.FindAsync(Id);
            }
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx.Customers.ToListAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAsync(Expression<Func<Customer, bool>> wherePredicate)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx.Customers.Where(wherePredicate).ToListAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetUndispossibleAsync()
        {
            return await _customerVehicleDbContext().Customers.ToListAsync();
        }

        public async Task<bool> IsExists(Expression<Func<Customer, bool>> wherePredicate)
        {
            using (var ctx = _customerVehicleDbContext())
            {
                return await ctx.Customers.AnyAsync(wherePredicate);
            }
        }

        //public async Task<int> DeleteAsync(int Id)
        //{
        //    using (var ctx = _customerVehicleDbContext())
        //    {
        //        var customer = await ctx.Customers.FindAsync(Id);

        //        customer.Deleted = true;

        //        return await ctx.SaveAsync();
        //    }
        //}

        //public async Task<Customer> GetCustomer(int CustomerId)
        //{
        //    using (var ctx = _customerVehicleDbContext())
        //    {
        //        return await ctx
        //                     .Customers
        //                     .Include(x => x.Vehicles)
        //                     .FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
        //    }
        //}

        //public async Task<int> InsertAsync(Customer entity)
        //{
        //    using (var ctx = _customerVehicleDbContext())
        //    {
        //        ctx.Customers.Add(entity);

        //        return await ctx.SaveAsync();
        //    }
        //}


        //public async Task<int> UpdateAsync(Customer entity)
        //{
        //    using (var ctx = _customerVehicleDbContext())
        //    {
        //        ctx.AttachEntity(entity);

        //        ctx.SetEntityState(entity, EntityState.Modified);

        //        return await ctx.SaveAsync();
        //    }
        //}
    }
}
