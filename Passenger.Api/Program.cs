﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Passenger.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*  var config = new ConfigurationBuilder()
                  .AddCommandLine(args)
                  .AddEnvironmentVariables(prefix: "ASPNETCORE...")
                  .Build();

              var host = new WebHostBuilder()
                  .UseConfiguration(config)
                  .UseKestrel()
                  .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseIISIntegration()
                  .UseStartup<Startup>()
                  .Build();

              host.Run(); */

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
