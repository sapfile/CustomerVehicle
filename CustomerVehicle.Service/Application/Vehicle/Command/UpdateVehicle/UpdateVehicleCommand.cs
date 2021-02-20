using CustomerVehicle.Service.Application.Vehicle.Queries.GetVehicle;
using MediatR;

namespace CustomerVehicle.Service.Application.Vehicle.Command.UpdateVehicle
{
    public class UpdateVehicleCommand : GetVehicleModel, IRequest<int>
    {
    }
}
