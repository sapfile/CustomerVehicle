using MediatR;

namespace CustomerVehicle.Service.Application.Vehicle.Command.DeleteVehicle
{
    public class DeleteVehicleCommand : IRequest<int>
    {
        public int VehicleId { get; set; }
    }
}
