using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    public class DriversController : ApiControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(ICommandDispatcher commandDispatcher, IDriverService driverService) : base(commandDispatcher)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var drivers = await _driverService.BrowseAsync();

            return Json(drivers);
        }

        [HttpPost("")] // /drivers
        public async Task<IActionResult> Post([FromBody] CreateDriver createDriver) //kod 201
        {
            await DispatchAsync(createDriver);
            //await _userService.RegisterAsync(createUser.Email, createUser.Username, createUser.Password);
            return Created($"drivers/{createDriver.UserId}", null);
        }
    }
}
