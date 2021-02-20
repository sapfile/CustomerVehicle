using CustomerVehicle.Repository.Interfaces.Application;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider
{
    internal class VehicleListProviderEngineSizeOver1100 : VehicleListProviderBaseWithParameter
    {
        public VehicleListProviderEngineSizeOver1100(
            IVehicleRepository vehicleRepository)
            :base(vehicleRepository)
        {
            expression = x => x.EngineSize > 1100;
        }
    }
}