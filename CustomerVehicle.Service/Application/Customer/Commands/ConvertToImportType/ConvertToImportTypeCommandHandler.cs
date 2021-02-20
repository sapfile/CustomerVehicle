using CustomerVehicle.Service.Application.Customer.Commands.ImportCustomer;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Customer.Commands.ConvertToImportType
{
    public class ConvertToImportTypeCommandHandler : IRequestHandler<ConvertToImportTypeCommand, ImportCustomerCommandCollection>
    {
        public async Task<ImportCustomerCommandCollection> Handle(ConvertToImportTypeCommand request, CancellationToken cancellationToken)
        {
            var customers = request
                            .CsvData
                            .GroupBy(x => new { x.CustomerId, x.DateOfBirth, x.Forename, x.Surname })
                            .Select(x => new ImportCustomerCommand
                            {
                                Surname = x.Key.Surname,
                                DateOfBirth = x.Key.DateOfBirth,
                                Forename = x.Key.Forename,
                                Vehicles = request
                                           .CsvData
                                           .Where(y => y.CustomerId == x.Key.CustomerId)
                                           .Select(y => new ImportVehicleCommand { 
                                               EngineSize = y.EngineSize,
                                               InteriorColour = y.InteriorColour,
                                               Manufacturer = y.Manufacturer,
                                               Model = y.Model,
                                               RegistationDate = y.RegistationDate,
                                               RegistrationNumber = y.RegistrationNumber
                                           })
                                           .ToList()
                            })
                            .ToList();

            return new ImportCustomerCommandCollection
            {
                Customers = customers
            };
        }
    }
}
