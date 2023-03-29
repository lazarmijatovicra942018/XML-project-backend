using AirplaneTicketingLibrary.Core.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
