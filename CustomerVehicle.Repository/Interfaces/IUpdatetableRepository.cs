using CustomerVehicle.Persistence.Entities;
using System.Threading.Tasks;

namespace CustomerVehicle.Repository.Interfaces
{
    public interface IUpdatetableRepository<T> where T : EntityBase
    {
        Task<int> UpdateAsync(T entity);
    }
}
