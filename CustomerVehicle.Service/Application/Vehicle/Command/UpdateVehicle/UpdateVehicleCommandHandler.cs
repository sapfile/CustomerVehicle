using AutoMapper;
using CustomerVehicle.Repository.Interfaces.Application;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Vehicle.Command.UpdateVehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, int>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleCommandHandler(
            IVehicleRepository vehicleRepository, 
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = _mapper.Map<Persistence.Entities.Vehicle>(request);

            return await _vehicleRepository.UpdateAsync(vehicle);
        }
    }
}
