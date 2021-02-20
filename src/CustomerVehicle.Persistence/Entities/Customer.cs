using System;
using System.Collections.Generic;

namespace CustomerVehicle.Persistence.Entities
{
    public class Customer : EntityBase
    {
        public int CustomerId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
