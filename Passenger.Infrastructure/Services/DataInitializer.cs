using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IDriverService _driverService;
        private readonly IDriverRouteService _driverRouteService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, IDriverService driverService, 
            IDriverRouteService driverRouteService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _driverService = driverService;
            _driverRouteService = driverRouteService;
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
                System.Diagnostics.Debug.WriteLine($"Created a new user: '{username}'.");
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "user"));
                tasks.Add(_driverService.CreateAsync(userId));
                tasks.Add(_driverService.SetVehicleAsync(userId, "BMW", "M3"));
                _logger.LogTrace($"Created a new driver for: '{username}'.");
                System.Diagnostics.Debug.WriteLine($"Created a new driver for: '{username}'.");

                tasks.Add(_driverRouteService.AddAsync(userId, "Work", 1, 1, 2, 2));
                tasks.Add(_driverRouteService.AddAsync(userId, "Home", 3, 1, 5, 2));

            }
            for (int i = 0; i <= 2; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                _logger.LogTrace($"Created a new user: '{username}'.");
                System.Diagnostics.Debug.WriteLine($"Created a new user: '{username}'.");
                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "admin"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized.");
            System.Diagnostics.Debug.WriteLine("Data was initialized.");
        }
    }
}
