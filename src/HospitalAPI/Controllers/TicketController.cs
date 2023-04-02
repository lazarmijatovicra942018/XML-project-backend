using AirplaneTicketingAPI.DTO;
using AirplaneTicketingAPI.Mappers;
using AirplaneTicketingLibrary.Core.Model;
using AirplaneTicketingLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AirplaneTicketingAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]

    public class TicketController : ControllerBase
    {

        private readonly ITicketService _ticketService;
        private readonly IGenericMapper<Ticket, TicketDTO> _mapper;

        public TicketController(ITicketService ticketService, IGenericMapper<Ticket, TicketDTO> mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllTickets()
        {
            return Ok(_mapper.ToDTO(_ticketService.GetAll().ToList()));
        }


        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            return Ok(_mapper.ToDTO(_ticketService.GetById(id)));
        }


        [HttpPost]
        public ActionResult Create(TicketDTO ticketDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ticket ticket = _mapper.ToModel(ticketDTO);
            _ticketService.Create(ticket);
            return CreatedAtAction("GetById", new { id = ticket.Id }, ticket);
        }

        [HttpGet("user/{userId}")]
        public ActionResult GetTicketsByUser(string userId)
        {
            return Ok(_ticketService.GetTicketsByUser(userId));
        }


    }
}
