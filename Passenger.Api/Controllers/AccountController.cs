using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPut("")] // /users
        [Route("password")]
        public async Task<IActionResult> Post([FromBody] ChangeUserPassword createUser) 
        {
            await DispatchAsync(createUser);
            return NoContent(); //204 - operacja sie powiodła
        }
    }
}
