using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var users = await _userService.BrowseAsync();
            if (users.Any())
            {
                _logger.LogTrace("Data was already initialized.");

                return;
            }

            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for (int i = 0; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                _logger.LogTrace($"Created a new user: '{username}'.");
                System.Diagnostics.Debug.WriteLine($"Created a new user: '{username}'.");
                await _userService.RegisterAsync(userId, $"user{i}@test.com",
                                                 username, "secret", "user");
                await _driverService.CreateAsync(userId);
                //tutaj wywala błąd 
                //await _driverService.SetVehicleAsync(userId, "BMW", "i8");
                //_logger.LogTrace($"Created a new driver for: '{username}'.");
                //System.Diagnostics.Debug.WriteLine($"Created a new driver for: '{username}'.");

                await _driverRouteService.AddAsync(userId, "Default route",
                    1, 1, 2, 2);
                await _driverRouteService.AddAsync(userId, "Job route",
                    3, 3, 5, 5);

            }
            for (int i = 0; i <= 2; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";
                _logger.LogTrace($"Created a new user: '{username}'.");
                System.Diagnostics.Debug.WriteLine($"Created a new user: '{username}'.");
                await _userService.RegisterAsync(userId, $"admin{i}@test.com",
                    username, "secret", "admin");
            }
            //await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized.");
            System.Diagnostics.Debug.WriteLine("Data was initialized.");
        }
    }
}
