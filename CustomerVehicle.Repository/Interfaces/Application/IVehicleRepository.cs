using CustomerVehicle.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerVehicle.Repository.Interfaces.Application
{
    public interface IVehicleRepository : IDeletetableRepository<Vehicle>,
                                          IInsertableRepository<Vehicle>,
                                          IUpdatetableRepository<Vehicle>,
                                          IGetableRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetAllVehicle(Expression<Func<Vehicle, bool>> wherePredicate);
        Task<IEnumerable<Vehicle>> GetAllVehicle();
    }
}