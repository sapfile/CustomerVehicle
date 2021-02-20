using AutoMapper;
using CustomerVehicle.Repository.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider
{
    internal abstract class VehicleListProviderBaseWithParameter : VehicleListProviderBase
    {
        protected Expression<Func<Persistence.Entities.Vehicle, bool>> expression;

        private readonly IVehicleRepository _vehicleRepository;
        internal VehicleListProviderBaseWithParameter(
            IVehicleRepository vehicleRepository)
            :base(vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        internal override Task<IEnumerable<Persistence.Entities.Vehicle>> GetAllVehiclesAsync()
        {
            return _vehicleRepository.GetAllVehicle(expression);
        }
    }
}
