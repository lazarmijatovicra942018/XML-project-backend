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
   //     [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public string Deaprture;

        public string Destination;

        public float Price;

        public int Capacity;

        public int Occupacy;

        public DateTime DepartureDate { get; set; }



    }
}
