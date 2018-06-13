using System.Threading.Tasks;
using Xunit;
using FluentAssertions; //fluentassertion - nuget zainstalowany Install-Package FluentAssertions -Version 5.4.0
using Passenger.Infrastructure.Services;
using Passenger.Core.Repositories;
using Moq; //moq - nuget zainstalowany 
using AutoMapper;
using Passenger.Core.Domain;

namespace Passenger.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task Test()
        {
            //mock - biblioteka do mockowania - tworznie obiektów przez biblioteke
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("user@gmail.com", "user", "secret");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);

        }
    }
}
