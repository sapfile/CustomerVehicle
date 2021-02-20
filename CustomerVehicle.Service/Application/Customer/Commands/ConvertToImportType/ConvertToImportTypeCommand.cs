using CustomerVehicle.Service.Application.Customer.Commands.ConvertFromCSV;
using CustomerVehicle.Service.Application.Customer.Commands.ImportCustomer;
using MediatR;
using System.Collections.Generic;

namespace CustomerVehicle.Service.Application.Customer.Commands.ConvertToImportType
{
    public class ConvertToImportTypeCommand : IRequest<ImportCustomerCommandCollection>
    {
        public IEnumerable<ConvertFromCSVCommandReturnModel> CsvData { get; set; }
    }
}
