using System.Collections.Generic;
using System.Linq;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetAllVehicles
{
    public class GetAllVehiclesModel
    {
        public IEnumerable<GetAllVehicleLookupModel> Vehicles { get; set; }

        public int DataCount => Vehicles.Count();
    }
}
