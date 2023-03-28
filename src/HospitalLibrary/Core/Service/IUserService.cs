using AirplaneTicketingLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketingLibrary.Core.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        public void Create(User user);
        public User GetById(int id);
    }
}
