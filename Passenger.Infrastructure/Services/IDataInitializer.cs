using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        //sedowanie danych
        Task SeedAsync();
    }
}
