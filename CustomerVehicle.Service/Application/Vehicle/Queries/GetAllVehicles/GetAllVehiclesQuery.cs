using MediatR;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles
{
    public class GetAllVehiclesQuery : IRequest<GetAllVehiclesModel>
    {
        public int ReportType { get; set; }
    }
}
