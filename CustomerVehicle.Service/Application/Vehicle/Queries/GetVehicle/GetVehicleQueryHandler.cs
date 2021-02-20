using AutoMapper;
using CustomerVehicle.Repository.Interfaces.Application;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetVehicle
{
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, GetVehicleModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetVehicleQueryHandler(
            ICustomerRepository customerRepository,
            IVehicleRepository vehicleRepository, 
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<GetVehicleModel> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetUndispossibleAsync();

            var vehicle = await _vehicleRepository.GetAsync(request.VehicleId);

            var retVal = _mapper.Map<GetVehicleModel>(vehicle);

            retVal.Customers = _mapper.Map<IEnumerable<GetCustomerModel>>(customers);

            return retVal;
        }
    }
}
