using CustomerVehicle.Service.Application.DataAccessObjects;
using System.Collections.Generic;

namespace CustomerVehicle.Service.Application.Vehicle.Queries.GetVehicle
{
    public class GetVehicleModel : VehicleDTO
    {
        public int VehicleId { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<GetCustomerModel> Customers { get; set; }
    }
}
