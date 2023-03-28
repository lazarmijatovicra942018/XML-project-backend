using AirplaneTicketingLibrary.Core.Model;
using System.Collections.Generic;

namespace AirplaneTicketingLibrary.Core.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Create(User user);
        public User GetById(int id);
    }
}
