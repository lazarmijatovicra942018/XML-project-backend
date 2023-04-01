using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirplaneTicketingLibrary.Core.Model
{
    public class Flight
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public float Price { get; set; }
        public int Capacity { get; set; }
        public int Occupancy { get; set; }
        public DateTime DepartureDate { get; set; }



    }
}
