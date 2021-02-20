using MediatR;
using System.Collections.Generic;

namespace CustomerVehicle.Service.Application.Customer.Commands.ImportCustomer
{
    public class ImportCustomerCommandCollection : IRequest<int>
    {
        public IEnumerable<ImportCustomerCommand> Customers { get; set; }
    }
}
