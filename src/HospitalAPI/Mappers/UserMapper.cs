using AirplaneTicketingAPI.DTO;
using AirplaneTicketingLibrary.Core.Enum;
using AirplaneTicketingLibrary.Core.Model;
using System.Collections.Generic;

namespace AirplaneTicketingAPI.Mappers
{
    public class UserMapper : IGenericMapper<User, UserDTO>
    {
        public UserDTO ToDTO(User user)
        {
            UserDTO userDTO = new UserDTO();
            userDTO.Id = user.Id;
            userDTO.Name = user.Name;
            userDTO.LastName = user.LastName;
            userDTO.Email = user.Email;
            userDTO.Password = user.Password;
            userDTO.Username = user.Username;
            userDTO.PlaceOfLiving = user.PlaceOfLiving;
            if (user.Role == Role.Host)
            {
                userDTO.Role = "Host";
            }
            if (user.Role == Role.Guest)
            {
                userDTO.Role = "Guest";
            }
            return userDTO;
        }

        public List<UserDTO> ToDTO(List<User>users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            
            foreach (User user in users)
            {
                UserDTO userDTO = new UserDTO();
                userDTO.Id = user.Id;
                userDTO.Name = user.Name;
                userDTO.LastName = user.LastName;
                userDTO.Email = user.Email; 
                userDTO.Password = user.Password;
                userDTO.Username = user.Username;
                userDTO.PlaceOfLiving = user.PlaceOfLiving;
                if (user.Role == Role.Host)
                {
                    userDTO.Role = "Host";
                }
                if (user.Role == Role.Guest)
                {
                    userDTO.Role = "Guest";
                }
                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }

        public User ToModel(UserDTO userDTO)
        {
            User user = new User();
            user.Name = userDTO.Name;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Username = userDTO.Username;
            user.PlaceOfLiving = userDTO.PlaceOfLiving;
            if (userDTO.Role.Equals("Host"))
            {
                user.Role = Role.Host;
            }
            if(userDTO.Role.Equals("Guest"))
            {
                user.Role = Role.Guest;
            }
            
            return user;
        }

        public List<User> ToModel(List<UserDTO> userDTOs)
        {
            List<User> users = new List<User>();

            foreach(var userDTO in userDTOs)
            {
                User user = new User();
                user.Name = userDTO.Name;
                user.LastName = userDTO.LastName;
                user.Email = userDTO.Email;
                user.Password = userDTO.Password;
                user.Username = userDTO.Username;
                user.PlaceOfLiving = userDTO.PlaceOfLiving;
                if (userDTO.Role.Equals("Host"))
                {
                    user.Role = Role.Host;
                }
                if (userDTO.Role.Equals("Guest"))
                {
                    user.Role = Role.Guest;
                }
                users.Add(user);
            }
            return users;
        }
    }
}

