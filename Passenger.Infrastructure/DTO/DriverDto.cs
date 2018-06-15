using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public DateTime UpdatedAd { get; set; }
    }
}
