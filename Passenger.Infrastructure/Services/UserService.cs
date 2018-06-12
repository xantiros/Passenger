using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using System;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) //konstruktor, na wejscie dajemy repozytorium, wstrzykujemy mappera
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);

            return _mapper.Map<User, UserDto>(user); //mapowanie usera na userdto (argument - źródło = user)
        }
        public void Register(string email, string username, string password)
        {
            var user = _userRepository.Get(email);
            if(user != null)
            {
                throw new Exception($"User with email: {email} already exists...");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            _userRepository.Add(user);
        }
    }
}
