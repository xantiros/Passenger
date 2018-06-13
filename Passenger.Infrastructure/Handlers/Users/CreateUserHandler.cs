﻿using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task HandleAsync(CreateUser command)
        {
            throw new NotImplementedException();
        }
    }
}
