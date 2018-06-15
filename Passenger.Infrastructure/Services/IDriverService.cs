using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService : IService
    {
        //Task<DriverDetailsDto> GetAsync(Guid userId);
        Task <DriverDto> GetAsync(Guid userId);
        Task CreateAsync(Guid userId);
        Task SetVehicleAsync(Guid userId, string brand, string name, int seats);
        Task DeleteAsync(Guid userId);
        Task<IEnumerable<DriverDto>> BrowseAsync();
    }
}
