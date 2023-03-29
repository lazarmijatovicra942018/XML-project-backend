using AirplaneTicketingLibrary.Core.Enum;
using System;

namespace AirplaneTicketingAPI.DTO
{
    public class UserDTO
    { 
        public String Id { get; set; }
        public String Username { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Role { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String PlaceOfLiving { get; set; }
    }
}
