using AirplaneTicketingLibrary.Core.Model;
using AirplaneTicketingLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketingLibrary.Core.Service
{


    public class FlightService : IFlightService
    {

        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public void Create(Flight flight)
        {
            _flightRepository.Create(flight);
        }

        public void Delete(Flight flight)
        {
            _flightRepository.Delete(flight);
        }

        public void DeleteById(string id)
        {
            _flightRepository.DeleteById(id);
        }

        public IEnumerable<Flight> GetAll()
        {
            return _flightRepository.GetAll();
        }

        public List<Flight> GetAllFlightsBySearch(DateTime searchDate, string searchDeparture, string searchDestination, int searchPassinger)
        {
            List<Flight> flights = new List<Flight>();
            foreach(Flight flight in GetAll())
            {
                
               

                DateTime wSearch = new DateTime(searchDate.Year, searchDate.Month, searchDate.Day, 1, 1, 1);
                DateTime wTime = new DateTime(flight.DepartureDate.Year, flight.DepartureDate.Month, flight.DepartureDate.Day, 1, 1, 1);


                if (wSearch == wTime && flight.Departure.Equals(searchDeparture) && flight.Destination.Equals(searchDestination) && flight.Capacity - flight.Occupancy >= searchPassinger)
                {
                    flights.Add(flight);
                }
            }
            return flights;
        }

        public Flight GetById(string id)
        {
            return _flightRepository.GetById(id);
        }

        public void Update(Flight flight)
        {
            _flightRepository.Update(flight);
        }

    }
}
