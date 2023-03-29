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
