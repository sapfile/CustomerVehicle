using CustomerVehicle.Service.Application.DataAccessObjects;

namespace CustomerVehicle.Service.Application.Customer.Commands.ConvertFromCSV
{
    public class ConvertFromCSVCommandReturnModel : JoinedDTO
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
    }
}