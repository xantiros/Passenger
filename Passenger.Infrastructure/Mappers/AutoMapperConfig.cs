using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Mappers
{
    public static class AutoMapperConfig //klasa konfiguracyjna
    {
        public static IMapper Initialize() //metoda zwraca konfiguracje interfejsu Imapper
         => new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<User, UserDto>(); //konfiguracja w postaci wyrażenia lambda;
                  cfg.CreateMap<Node, NodeDto>();
                  cfg.CreateMap<Route, RouteDto>();
                  cfg.CreateMap<User, UserDto>();
                  cfg.CreateMap<Vehicle, VehicleDto>();
                  cfg.CreateMap<Driver, DriverDto>();
                  cfg.CreateMap<Driver, DriverDetailsDto>();
              })
            .CreateMapper(); //wywołanie metody

    }
}
