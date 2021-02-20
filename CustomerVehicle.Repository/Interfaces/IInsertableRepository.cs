using CustomerVehicle.Persistence.Entities;
using System.Threading.Tasks;

namespace CustomerVehicle.Repository.Interfaces
{
    public interface IInsertableRepository<T> where T : EntityBase
    {
        Task<int> InsertAsync(T entity);
    }
}
