﻿using Autofac;
using Microsoft.Extensions.Configuration;
using Passenger.Infrastructure.IoC.Modules;
using Passenger.Infrastructure.Mappers;

namespace Passenger.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance(); //konfiguracja, jedna instancja
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModulle>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}
