using CustomerVehicle.Service.Application.Vehicle.Command.DeleteVehicle;
using CustomerVehicle.Service.Application.Vehicle.Command.UpdateVehicle;
using CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles;
using CustomerVehicle.Service.Application.Vehicle.Queries.GetVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerVehicle.UI.Controllers
{
    public class VehicleController : ControllerBase
    {
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await GetVehicleData(1, cancellationToken);

            return View(data);
        }


        [HttpGet("GetVehicles/{reportType}")]
        public async Task<ActionResult> GetVehicles(int reportType, CancellationToken cancellationToken)
        {
            var data = await GetVehicleData(reportType, cancellationToken);

            return PartialView("Partial/_VehicleList", data);
        }

        private async Task<GetAllVehiclesModel> GetVehicleData(int reportType, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllVehiclesQuery { ReportType = reportType }, cancellationToken);
        }

        public async Task<ActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var vehicle = await Mediator.Send(new GetVehicleQuery { VehicleId = id }, cancellationToken);

            return View(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult> Details(UpdateVehicleCommand updateVehicleCommand, CancellationToken cancellationToken)
        {
            try
            {
                await Mediator.Send(updateVehicleCommand, cancellationToken);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost("Delete/{id}")]
        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new DeleteVehicleCommand { VehicleId = id }, cancellationToken);
        }
    }
}
