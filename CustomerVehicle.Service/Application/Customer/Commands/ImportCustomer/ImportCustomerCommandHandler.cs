using AutoMapper;
using CustomerVehicle.Repository.Interfaces.Application;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Customer.Commands.ImportCustomer
{
    public class ImportCustomerCommandHandler : IRequestHandler<ImportCustomerCommandCollection, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public ImportCustomerCommandHandler(
            ICustomerRepository customerRepository, 
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(ImportCustomerCommandCollection request, CancellationToken cancellationToken)
        {
            var customers = _mapper.Map<IEnumerable<Persistence.Entities.Customer>>(request.Customers);

            return await _customerRepository.BulkInsert(customers);
        }
    }
}
