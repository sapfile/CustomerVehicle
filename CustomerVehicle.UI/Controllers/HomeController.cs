using CustomerVehicle.Service.Application.Customer.Commands.ConvertFromCSV;
using CustomerVehicle.Service.Application.Customer.Commands.ConvertToImportType;
using CustomerVehicle.Service.Application.Customer.Commands.ImportCustomer;
using CustomerVehicle.UI.Models;
using CustomerVehicle.UI.Models.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.UI.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] ImportFileViewModel importFile, CancellationToken cancellationToken)
        {
            var csvData = await GetCsvData(importFile.File, cancellationToken);

            var dataToImport = await GetDataToImport(csvData, cancellationToken);

            var import = await Mediator.Send(dataToImport, cancellationToken);

            return RedirectToAction("Index", "Vehicle");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<IEnumerable<ConvertFromCSVCommandReturnModel>> GetCsvData(IFormFile file, CancellationToken cancellationToken)
        {
            var command = new ConvertFromCSVCommand
            {
                FileName = file.FileName,
                FileStream = file.OpenReadStream()
            };

            return await Mediator.Send(command, cancellationToken);
        }

        private async Task<ImportCustomerCommandCollection> GetDataToImport(IEnumerable<ConvertFromCSVCommandReturnModel> csvData, 
                                                                            CancellationToken cancellationToken)
        {
            var command = new ConvertToImportTypeCommand
            {
                CsvData = csvData
            };

            return await Mediator.Send(command, cancellationToken);
        }
    }
}
