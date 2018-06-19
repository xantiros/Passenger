﻿using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class DeleteDriverHandler : ICommandHandler<DeleteDriver> //ok
    {
        private readonly IDriverService _driverService;

        public DeleteDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task HandleAsync(DeleteDriver command)
        {
            await _driverService.DeleteAsync(command.UserId);
        }
    }
}