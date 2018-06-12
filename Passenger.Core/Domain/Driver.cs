﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; } //pojazd - valiu object
        public IEnumerable<Route> Routes { get; protected set; } //ścieżki/trasy
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }

        protected Driver()
        {
        }

        public Driver (Guid userId)
        {
            UserId = userId;
        }

    }
}
