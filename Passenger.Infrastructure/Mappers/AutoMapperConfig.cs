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
                  cfg.CreateMap<Driver, DriverDto>();
              })
            .CreateMapper(); //wywołanie metody

    }
}
