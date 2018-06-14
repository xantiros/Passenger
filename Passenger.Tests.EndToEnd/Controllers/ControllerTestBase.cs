using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using System.Net.Http;
using System.Text;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        public ControllerTestBase()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            Client = Server.CreateClient();
        }

        //pomocnicza metoda
        protected static StringContent GetPayload(object data) //zapisuje obiekt w postaci jsona
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
