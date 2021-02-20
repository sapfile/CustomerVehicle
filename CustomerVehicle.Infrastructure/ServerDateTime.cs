using CustomerVehicle.Infrastructure.Interfaces;
using System;

namespace CustomerVehicle.Infrastructure
{
    internal class ServerDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
