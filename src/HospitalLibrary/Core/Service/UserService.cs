using AirplaneTicketingLibrary.Core.Model;
using AirplaneTicketingLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AirplaneTicketingLibrary.Core.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly JwtGenerator _jwtGenerator;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
            _jwtGenerator = new JwtGenerator();
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Create(User user)
        {
            user.Password = CreateHashPassword(user.Password);
            _userRepository.Create(user);
        }
        public User GetById(string id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByEmail(String email)
        {
            return _userRepository.GetByEmail(email);
        }

        public AuthenticationToken Login(string username, string password)
        {
            var user = _userRepository.Login(username, password);

            if (user == null) return null;

            return _jwtGenerator.GenerateAccessToken(user.Id, user.Role.ToString());
        }

        public String CreateHashPassword(string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash value of the password byte array
                byte[] hashBytes = sha256Hash.ComputeHash(passwordBytes);

                // Convert the hash byte array to a string representation
                string hashString = Convert.ToBase64String(hashBytes);

                return hashString;
            }
        }

        public User WhoIAm(string token)
        {
            return _userRepository.WhoIAm(token);
        }
    }
}