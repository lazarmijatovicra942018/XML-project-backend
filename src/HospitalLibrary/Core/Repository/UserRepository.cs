using AirplaneTicketingLibrary.Core.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace AirplaneTicketingLibrary.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IOptions<MongoDBSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _users = mongoDatabase.GetCollection<User>(databaseSettings.Value.UsersCollectionName);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Find(_ => true).ToList();
        }
    }
}
