using CustomerVehicle.Persistence.Entities;
using System.Threading.Tasks;

namespace CustomerVehicle.Repository.Interfaces
{
    public interface IDeletetableRepository<T> where T : EntityBase
    {
        Task<int> DeleteAsync(int Id);
    }
}
