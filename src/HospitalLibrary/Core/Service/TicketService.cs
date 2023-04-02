using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirplaneTicketingLibrary.Core.Model;
using AirplaneTicketingLibrary.Core.Repository;

namespace AirplaneTicketingLibrary.Core.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public void Create(Ticket ticket)
        {
            _ticketRepository.Create(ticket);
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
            return _ticketRepository.GetAll();
        }

        public Ticket GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketsByUser(string userId)
        {
            IEnumerable<Ticket> karte = new List<Ticket>(); ;

            foreach (var ticket in _ticketRepository.GetAll())
            {
                if (ticket.UserId == userId)
                {
                    karte.Append(ticket);
                }
            }
            return karte;
        }

        public void Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
