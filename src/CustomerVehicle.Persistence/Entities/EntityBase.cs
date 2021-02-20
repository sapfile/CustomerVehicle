using System;

namespace CustomerVehicle.Persistence.Entities
{
    public abstract class EntityBase
    {
        public DateTime InsertedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
