using CustomerVehicle.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerVehicle.Repository.Interfaces
{
    public interface IGetableRepository<T> where T : EntityBase
    {
        Task<T> GetAsync(int Id);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> wherePredicate);
        Task<bool> IsExists(Expression<Func<T, bool>> wherePredicate);
    }
}
