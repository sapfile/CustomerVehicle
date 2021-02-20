using AutoMapper;
using CustomerVehicle.Repository.Interfaces.Application;
using CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles.VehicleProvider;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles
{
    public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesQuery, GetAllVehiclesModel>
    {
        private readonly VehicleListProviderFactory _vehicleListProviderFactory;
        private readonly IMapper _mapper;

        public GetAllVehiclesHandler(
            VehicleListProviderFactory vehicleListProviderFactory,
            IMapper mapper)
        {
            _vehicleListProviderFactory = vehicleListProviderFactory;
            _mapper = mapper;
        }

        public async Task<GetAllVehiclesModel> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            var type = _vehicleListProviderFactory.VehicleListProviderType(request.ReportType);
            
            var vehicles = await type.GetAllVehiclesAsync();

            return new GetAllVehiclesModel
            {
                Vehicles = _mapper.Map<IEnumerable<GetAllVehicleLookupModel>>(vehicles)
            };
        }
    }
}
