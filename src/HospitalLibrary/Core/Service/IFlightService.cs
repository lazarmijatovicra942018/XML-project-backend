using AirplaneTicketingLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketingLibrary.Core.Service
{
    public interface IFlightService
    {


        IEnumerable<Flight> GetAll();
        void Create(Flight flight);
        public Flight GetById(int id);

        void Update(Flight flight);
        void Delete(Flight flight);

        void DeleteById(int id);
    }
}
