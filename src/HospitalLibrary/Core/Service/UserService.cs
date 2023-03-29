using AirplaneTicketingLibrary.Core.Model;
using AirplaneTicketingLibrary.Core.Repository;
using System;
using System.Collections.Generic;

namespace AirplaneTicketingLibrary.Core.Service
{
    public class UserService : IUserService
    {
    
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }
        public User GetById(string id)
        {
            return _userRepository.GetById(id);
        }
    }
}
