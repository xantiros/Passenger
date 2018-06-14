using Autofac;
using Passenger.Infrastructure.Services;
using System.Reflection;

namespace Passenger.Infrastructure.IoC.Modules
{
    public class ServiceModulle : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModulle)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IService>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                   .As<IEncrypter>()
                   .SingleInstance();

        }
        //base Load(builder);
    }
}
