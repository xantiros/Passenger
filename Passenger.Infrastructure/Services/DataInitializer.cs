﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for (int i = 0; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                _logger.LogTrace($"Created a new user: '{username}'.");
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "user"));
            }
            for (int i = 0; i <= 2; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                _logger.LogTrace($"Created a new user: '{username}'.");
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "admin"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized.");
        }
    }
}
