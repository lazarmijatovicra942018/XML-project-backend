using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirplaneTicketingLibrary.Core.Model;

namespace AirplaneTicketingLibrary.Core.Repository
{
    public interface ITicketRepository
    {

        IEnumerable<Ticket> GetAll();
        void Create(Ticket ticket);
        public Ticket GetById(string id);

        void Update(Ticket ticket);
        void Delete(Ticket ticket);

        void DeleteById(string id);

    }
}
