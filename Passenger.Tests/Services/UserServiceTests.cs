using System.Threading.Tasks;
using Xunit;
using FluentAssertions; //fluentassertion - nuget zainstalowany Install-Package FluentAssertions -Version 5.4.0
using Passenger.Infrastructure.Services;
using Passenger.Core.Repositories;
using Moq; //moq - nuget zainstalowany 
using AutoMapper;
using Passenger.Core.Domain;
using System;

namespace Passenger.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task Register_async_should_invoike_add_async_on_repository()
        {
            //mock - biblioteka do mockowania - tworznie obiektów przez biblioteke
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypter = new Encrypter();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, encrypter, mapperMock.Object);
            await userService.RegisterAsync(Guid.NewGuid(),"user@gmail.com", "user", "user", "secret");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);

        }

        [Fact]
        public async Task when_calling_get_async_and_user_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypter = new Encrypter();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, encrypter, mapperMock.Object);
            await userService.GetAsync("user1@email.com");

            var user = new User(Guid.NewGuid(), "user1@email.com", "user1", "secret", "user", "salt");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                              .ReturnsAsync(user);

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task when_calling_get_async_and_user_does_not_exist_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypter = new Encrypter();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, encrypter, mapperMock.Object);
            await userService.GetAsync("user@email.com");

            userRepositoryMock.Setup(x => x.GetAsync("user@email.com"))
                              .ReturnsAsync(() => null);

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
