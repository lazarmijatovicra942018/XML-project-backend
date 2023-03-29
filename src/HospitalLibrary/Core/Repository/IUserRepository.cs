using AirplaneTicketingLibrary.Core.Model;
using System;
using System.Collections.Generic;

namespace AirplaneTicketingLibrary.Core.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Create(User user);
        public User GetById(string id);
        public Boolean IsUsernameExist(String username);
        public User GetByUsername(String username);
        public Boolean IsEmailExist(String email);
    }
}
