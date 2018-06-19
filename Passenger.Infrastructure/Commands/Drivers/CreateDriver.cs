namespace Passenger.Infrastructure.Commands.Drivers.Models
{
    public class CreateDriver : AuthenticatedCommandBase
    {
        public DriverVehicle Vehicle { get; set; }
    }
}
