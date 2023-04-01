using AirplaneTicketingAPI.DTO;
using AirplaneTicketingLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketingAPI.Mappers
{
    public class FlightMapper : IGenericMapper<Flight, FlightDTO>
    {
        public FlightDTO ToDTO(Flight flight)
        {
            FlightDTO flightDTO = new FlightDTO();

            flightDTO.Id = flight.Id;
            flightDTO.Departure = flight.Departure;
            flightDTO.Destination = flight.Destination;
            flightDTO.Price = flight.Price;
            flightDTO.Capacity = flight.Capacity;
            flightDTO.DepartureDate = flight.DepartureDate;
            flightDTO.Occupancy = flight.Occupancy;


            return flightDTO;
        }

        public List<FlightDTO> ToDTO(List<Flight> flights)
        {
            List<FlightDTO> flightDTOs = new List<FlightDTO>();


            foreach(Flight flight in flights)
            {
                FlightDTO flightDTO = new FlightDTO();

                flightDTO.Id = flight.Id;
                flightDTO.Departure = flight.Departure;
                flightDTO.Destination = flight.Destination;
                flightDTO.Price = flight.Price;
                flightDTO.Capacity = flight.Capacity;
                flightDTO.DepartureDate = flight.DepartureDate;
                flightDTO.Occupancy = flight.Occupancy;

                flightDTOs.Add(flightDTO);

            }


            return flightDTOs;
        }

        public Flight ToModel(FlightDTO flightDTO)
        {

            Flight flight = new Flight();

            flight.Id = flightDTO.Id;
            flight.Departure = flightDTO.Departure;
            flight.Destination = flightDTO.Destination;
            flight.Price = flightDTO.Price;
            flight.Capacity = flightDTO.Capacity;
            flight.DepartureDate = flightDTO.DepartureDate;
            flight.Occupancy = flightDTO.Occupancy;


            return flight;


        }

        public List<Flight> ToModel(List<FlightDTO> flightDTOs)
        {
            List<Flight> flights = new List<Flight>();


            foreach (FlightDTO flightDTO in flightDTOs)
            {
                Flight flight = new Flight();

                
                flight.Id = flightDTO.Id;
                flight.Departure = flightDTO.Departure;
                flight.Destination = flightDTO.Destination;
                flight.Price = flightDTO.Price;
                flight.Capacity = flightDTO.Capacity;
                flight.DepartureDate = flightDTO.DepartureDate;
                flight.Occupancy = flightDTO.Occupancy;

                flights.Add(flight);

            }


            return flights;



        }

    }
}
