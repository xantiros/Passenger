using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    public class DriverController : ApiControllerBase
    {
        public DriverController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPost("")] // /drivers
        public async Task<IActionResult> Post([FromBody] CreateDriver createDriver) //kod 201
        {
            await DispatchAsync(createDriver);
            //await _userService.RegisterAsync(createUser.Email, createUser.Username, createUser.Password);
            return Created($"users/{createDriver}", new object());
        }
    }
}
