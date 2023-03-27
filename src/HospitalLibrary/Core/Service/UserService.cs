using AirplaneTicketingLibrary.Core.Model;
using AirplaneTicketingLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketingLibrary.Core.Service
{
    public class UserService : IUserService
    {
    
    private readonly IUserRepository _userRepository;
        
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        } 
    }
}
