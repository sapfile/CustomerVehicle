using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerVehicle.UI.Models.Vehicle
{
    public class AddNewVehicleModel
    {
        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int EngineSize { get; set; }

        [Required]
        public DateTime RegistationDate { get; set; }

        [Required]
        public string InteriorColour { get; set; }
    }
}
