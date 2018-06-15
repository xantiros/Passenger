﻿using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public Vehicle Vehicle { get; protected set; } //pojazd - valiu object
        public IEnumerable<Route> Routes { get; protected set; } //ścieżki/trasy
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Driver()
        {
        }

        public Driver (User user)
        {
            UserId = user.Id;
            Name = user.Username;
        }

        public void SetVehicleAsync(string brand, string name, int seats)
        {
            Vehicle = Vehicle.Create(brand, name, seats);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
