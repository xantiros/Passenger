using System;
using System.Collections.Generic;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto //ok
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public VehicleDto Vehicle { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}