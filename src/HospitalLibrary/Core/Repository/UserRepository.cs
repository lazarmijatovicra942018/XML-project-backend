using AirplaneTicketingLibrary.Core.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;

namespace AirplaneTicketingLibrary.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = client.GetDatabase("mydatabase");
            _users = mongoDatabase.GetCollection<User>("myusers");
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Find(_ => true).ToList();
        }

        public void Create(User user)
        {    
            if(IsUsernameExist(user.Username) == false)
            {
                _users.InsertOne(user);
            }
            else
            {
                return;
            }     
        } 

        public User GetById(String id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id);
            var user = _users.Find(filter).FirstOrDefault();
            

            if(user != null)
            {
                return user;
            }
            return null;
        }

        public User GetByUsername(String username)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var user = _users.Find(filter).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public User GetByEmail(String email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            var user = _users.Find(filter).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public Boolean IsUsernameExist(String username)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var user = _users.Find(filter).FirstOrDefault();
            if(user != null)
            {
                return true;
            }
            return false;
        }

        public Boolean IsEmailExist(String email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            var user = _users.Find(filter).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public User Login(string email, string password)
        {
            
            foreach (User user in GetAll())
            {
                if (user.Email.Equals(email) && VerifyPassword(password,user.Password) == true)
                {
                    return user;
                }
            }
            return null;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Convert the password string to a byte array
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            // Create a new instance of the SHA256 algorithm
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash value of the password byte array
                byte[] hashBytes = sha256Hash.ComputeHash(passwordBytes);

                // Convert the hash byte array to a string representation
                string hashString = Convert.ToBase64String(hashBytes);

                // Compare the newly hashed password with the existing hashed password
                return hashString.Equals(hashedPassword);
            }
        }

        public User WhoIAm(string token)
        {
            // Decode the token
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            // Extract information from the token
            string Id = jwtToken.Claims.First(claim => claim.Type == "Id").Value;
            string Role = jwtToken.Claims.First(claim => claim.Type == "Role").Value;

            User Iam = new User();
            
            Iam = GetById(Id);
            
            return Iam;
        }




    }  
}
