using AirplaneTicketingLibrary.Core.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketingLibrary.Core.Repository
{
    public class FlightRepository : IFlightRepository
    {

        private readonly IMongoCollection<Flight> _flights;

        public FlightRepository()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = client.GetDatabase("mydatabase");
         
            _flights = mongoDatabase.GetCollection<Flight>("flights");

        }

        public void Create(Flight flight)
        {
            _flights.InsertOne(flight);
        }

        public void Delete(Flight flight)
        {
            var filter = Builders<Flight>.Filter.Eq(u => u.Id, flight.Id);
            _flights.DeleteOne(filter);
        }

        public void DeleteById(string id)
        {
            var filter = Builders<Flight>.Filter.Eq(u => u.Id, id);
            _flights.DeleteOne(filter);

        }

        public IEnumerable<Flight> GetAll()
        {
            return _flights.Find(_ => true).ToList();
        }

        public Flight GetById(string id)
        {
            var filter = Builders<Flight>.Filter.Eq(u => u.Id, id);
            var flight = _flights.Find(filter).FirstOrDefault();
            return flight;
        }

        public void Update(Flight flight)
        {
            var filter = Builders<Flight>.Filter.Eq(u => u.Id, flight.Id);
            _flights.ReplaceOne(filter,flight);
        }



    }
}
