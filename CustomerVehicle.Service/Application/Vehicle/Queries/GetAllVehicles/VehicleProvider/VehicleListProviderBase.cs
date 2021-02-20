using AutoMapper;
using CustomerVehicle.Repository.Interfaces.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider
{
    internal abstract class VehicleListProviderBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        internal VehicleListProviderBase(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        internal virtual async Task<IEnumerable<Persistence.Entities.Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehicleRepository.GetAllVehicle();
        }
    }
}
