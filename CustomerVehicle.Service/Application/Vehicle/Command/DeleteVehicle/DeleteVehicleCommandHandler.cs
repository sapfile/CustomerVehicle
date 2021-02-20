using CustomerVehicle.Repository.Interfaces.Application;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Vehicle.Command.DeleteVehicle
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, int>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DeleteVehicleCommandHandler(
            IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _vehicleRepository.DeleteAsync(request.VehicleId);
        }
    }
}
