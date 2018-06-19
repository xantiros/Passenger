using System.Collections.Generic;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDetailsDto : DriverDto //ok
    {
        public IEnumerable<RouteDto> Routes { get; set; }
    }
}