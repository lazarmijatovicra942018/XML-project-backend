using AirplaneTicketingLibrary.Core.Model;
using MongoDB.Bson;
using MongoDB.Driver;
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
            _users = mongoDatabase.GetCollection<User>("mycollection");
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Find(_ => true).ToList();
        }

        public void Create(User user)
        {
            _users.InsertOne(user);
        } 

        public User GetById(int id)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, id); 
            var user = _users.Find(filter).FirstOrDefault();
            return user;
        }
    }
}
