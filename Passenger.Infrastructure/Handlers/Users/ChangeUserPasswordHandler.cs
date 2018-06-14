using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Users
{
    class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
