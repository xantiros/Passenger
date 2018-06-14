using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
     //tu wiadomo ze to /users
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, 
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email); //kod http 404
            if(user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost("")] // /users
        public async Task<IActionResult> Post([FromBody] CreateUser createUser) //kod 201
        {
            await CommandDispatcher.DispatchAsync(createUser);
            //await _userService.RegisterAsync(createUser.Email, createUser.Username, createUser.Password);
            return Created($"users/{createUser.Email}", new object());
        }
    }
}
