using MediatR;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetVehicle
{
    public class GetVehicleQuery : IRequest<GetVehicleModel>
    {
        public int VehicleId { get; set; }
    }
}
