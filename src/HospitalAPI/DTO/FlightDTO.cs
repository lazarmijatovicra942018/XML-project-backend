using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketingAPI.DTO
{
    public class FlightDTO
    {

        public string Id { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public float Price { get; set; }

        public int Capacity { get; set; }

        public int Occupancy { get; set; }

        public DateTime DepartureDate { get; set; }
    }
}
