using AutoMapper;
using CustomerVehicle.Repository.Interfaces.Application;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider
{
    internal class VehicleListProviderAll : VehicleListProviderBase
    {
        public VehicleListProviderAll(
            IVehicleRepository vehicleRepository) 
            : base(vehicleRepository)
        {
             
        }
    }
}
