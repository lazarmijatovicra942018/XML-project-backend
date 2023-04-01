using AirplaneTicketingAPI.DTO;
using AirplaneTicketingAPI.Mappers;
using AirplaneTicketingLibrary.Core.Model;
using AirplaneTicketingLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace AirplaneTicketingAPI.Controllers

{

    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {


        private readonly IFlightService _flightService;
        private readonly IGenericMapper<Flight, FlightDTO> _mapper;

        public FlightController(IFlightService flightService, IGenericMapper<Flight, FlightDTO> mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        [HttpGet]

      
        [HttpGet]
        public ActionResult GetAllFlieghts()
        {
            return Ok(_mapper.ToDTO(_flightService.GetAll().ToList()));
        }


        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            return Ok(_mapper.ToDTO(_flightService.GetById(id)));
        }


        [HttpPost]
        public ActionResult Create(FlightDTO flightDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Flight flight = _mapper.ToModel(flightDTO);
            _flightService.Create(flight);
            return CreatedAtAction("GetById", new { id = flight.Id }, flight);
        }

        // PUT api/flight/2
        [HttpPut("{id}")]
        public ActionResult Update(string id, Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flight.Id)
            {
                return BadRequest();
            }

            try
            {
                _flightService.Update(flight);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(flight);
        }

        // DELETE api/flight/2
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var flight = _flightService.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }

            _flightService.Delete(flight);
            return NoContent();
        }



    }

}
