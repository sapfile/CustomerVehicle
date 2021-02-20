using CustomerVehicle.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerVehicle.Repository.Interfaces.Application
{
    public interface ICustomerRepository : IGetableRepository<Customer>
    {
        Task<int> BulkInsert(IEnumerable<Customer> data);
        Task<IEnumerable<Customer>> GetUndispossibleAsync();
    }
}