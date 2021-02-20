using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Interfaces
{
    public interface IDataValidationService
    {
        Task<bool> IsVehicleExists(int VehicleId, CancellationToken cancellationToken);
        Task<bool> IsRegNumberHasOtherVehicle(int VehicleId, string RegNumber, CancellationToken cancellationToken);
    }
}
