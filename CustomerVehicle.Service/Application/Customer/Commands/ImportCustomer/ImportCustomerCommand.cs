using CustomerVehicle.Service.Application.DataAccessObjects;
using System.Collections.Generic;

namespace CustomerVehicle.Service.Application.Customer.Commands.ImportCustomer
{
    public class ImportCustomerCommand : CustomerDTO
    {
        internal  IEnumerable<ImportVehicleCommand> Vehicles { get; set; }
    }
}