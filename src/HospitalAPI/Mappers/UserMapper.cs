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
            if (user.Role == Role.UnauthenticatedUser)
            {
                userDTO.Role = "UnauthenticatedUser";
            }
            if (user.Role == Role.OrdinaryUser)
            {
                userDTO.Role = "OrdinaryUser";
            }
            if (user.Role == Role.Admin)
            {
                userDTO.Role = "Admin";
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
                if (user.Role == Role.UnauthenticatedUser)
                {
                    userDTO.Role = "UnauthenticatedUser";
                }
                if (user.Role == Role.OrdinaryUser)
                {
                    userDTO.Role = "OrdinaryUser";
                }
                if (user.Role == Role.Admin)
                {
                    userDTO.Role = "Admin";
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
            if (userDTO.Role.Equals("UnauthenticatedUser"))
            {
                user.Role = Role.UnauthenticatedUser;
            }
            if(userDTO.Role.Equals("OrdinaryUser"))
            {
                user.Role = Role.OrdinaryUser;
            }
            if (userDTO.Role.Equals("Admin"))
            {
                user.Role = Role.Admin;
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
                if (userDTO.Role.Equals("UnauthenticatedUser"))
                {
                    user.Role = Role.UnauthenticatedUser;
                }
                if (userDTO.Role.Equals("OrdinaryUser"))
                {
                    user.Role = Role.OrdinaryUser;
                }
                if (userDTO.Role.Equals("Admin"))
                {
                    user.Role = Role.Admin;
                }
                users.Add(user);
            }
            return users;
        }
    }
}

