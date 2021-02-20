using CsvHelper;
using MediatR;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.Service.Application.Customer.Commands.ConvertFromCSV
{
    partial class ConvertFromCSVCommandHandler : IRequestHandler<ConvertFromCSVCommand, IEnumerable<ConvertFromCSVCommandReturnModel>>
    {
        public async Task<IEnumerable<ConvertFromCSVCommandReturnModel>> Handle(ConvertFromCSVCommand request, CancellationToken cancellationToken)
        {
            using (var reader = new StreamReader(request.FileStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<ConvertFromCSVCommandReturnModel>().ToList();
            }
        }
    }
}
