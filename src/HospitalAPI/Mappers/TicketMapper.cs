using System.Collections.Generic;
using AirplaneTicketingAPI.DTO;
using AirplaneTicketingLibrary.Core.Model;

namespace AirplaneTicketingAPI.Mappers
{
    public class TicketMapper : IGenericMapper<Ticket, TicketDTO>
    {
        public TicketDTO ToDTO(Ticket ticket)
        {

            TicketDTO ticketDTO = new TicketDTO();

            ticketDTO.Id = ticket.Id;
            ticketDTO.UserId = ticket.UserId;
            ticketDTO.FlightId = ticket.FlightId;
        
            return ticketDTO;
        }

        public List<TicketDTO> ToDTO(List<Ticket> tickets)
        {
            List<TicketDTO> ticketDTOs = new List<TicketDTO>();

            foreach (Ticket ticket in tickets)
            {
                TicketDTO ticketDTO = new TicketDTO();

                ticketDTO.Id = ticket.Id;
                ticketDTO.UserId = ticket.UserId;
                ticketDTO.FlightId = ticket.FlightId;

                ticketDTOs.Add(ticketDTO);

            }

            return ticketDTOs;
        }

        public Ticket ToModel(TicketDTO ticketDto)
        {
            Ticket ticket = new Ticket();

            ticket.Id = ticketDto.Id;
            ticket.UserId = ticketDto.UserId;
            ticket.FlightId = ticketDto.FlightId;
        
            return ticket;
        }

        public List<Ticket> ToModel(List<TicketDTO> ticketDtos)
        {
            List<Ticket> tickets = new List<Ticket>();


            foreach (TicketDTO flightDTO in ticketDtos)
            {
                Ticket ticket = new Ticket();


                ticket.Id = flightDTO.Id;
                ticket.UserId = flightDTO.UserId;
                ticket.FlightId = flightDTO.FlightId;

                tickets.Add(ticket);
            }

            return tickets;
        }
    }
}
