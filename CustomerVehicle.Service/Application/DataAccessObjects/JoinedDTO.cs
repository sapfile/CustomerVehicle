﻿using System;

namespace CustomerVehicle.Service.Application.DataAccessObjects
{
    public abstract class JoinedDTO : ICustomerDTO, IVehicleDTO
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RegistrationNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int EngineSize { get; set; }
        public DateTime RegistationDate { get; set; }
        public string InteriorColour { get; set; }
    }
}
