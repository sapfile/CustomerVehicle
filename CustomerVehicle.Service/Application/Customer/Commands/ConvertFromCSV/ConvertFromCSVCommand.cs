using MediatR;
using System.Collections.Generic;
using System.IO;

namespace CustomerVehicle.Service.Application.Customer.Commands.ConvertFromCSV
{
    public class ConvertFromCSVCommand : IRequest<IEnumerable<ConvertFromCSVCommandReturnModel>>
    {
        public string FileName { get; set; }
        public Stream FileStream { get; set; }
    }
}
