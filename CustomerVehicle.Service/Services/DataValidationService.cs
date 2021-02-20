using CustomerVehicle.Repository.Interfaces.Application;
using CustomerVehicle.Service.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Services
{
    internal class DataValidationService : IDataValidationService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DataValidationService(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<bool> IsRegNumberHasOtherVehicle(int VehicleId, string RegNumber, CancellationToken cancellationToken)
        {
            return await _vehicleRepository.IsExists(x => x.VehicleId != VehicleId && x.RegistrationNumber.Trim().Equals(RegNumber.Trim()));
        }

        public async Task<bool> IsVehicleExists(int VehicleId, CancellationToken cancellationToken)
        {
            return await _vehicleRepository.IsExists(x => x.VehicleId == VehicleId);
        }
    }
}
