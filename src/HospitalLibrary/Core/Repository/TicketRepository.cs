using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirplaneTicketingLibrary.Core.Model;
using MongoDB.Driver;

namespace AirplaneTicketingLibrary.Core.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IMongoCollection<Ticket> _tickets;


        public TicketRepository()
        {

            var client = new MongoClient("mongodb://root:password@mongo:27017");
            var mongoDatabase = client.GetDatabase("mydatabase");
            _tickets = mongoDatabase.GetCollection<Ticket>("tickets");

        }


        public void Create(Ticket ticket)
        {
            _tickets.InsertOne(ticket);
        }

        public void Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _tickets.Find(_ => true).ToList();
        }

        public Ticket GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
