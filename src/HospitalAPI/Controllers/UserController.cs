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
    public class UserController : ControllerBase
    {
     
        private readonly IUserService _userService;
        private readonly IGenericMapper<User, UserDTO> _mapper;

        public UserController(IUserService userService, IGenericMapper<User, UserDTO> userMapper)
        {
            _userService = userService;
            _mapper = userMapper;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(_mapper.ToDTO(_userService.GetAll().ToList()));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_mapper.ToDTO(_userService.GetById(id)));
        }

        [HttpPost]
        public ActionResult Create(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = _mapper.ToModel(userDTO);
            _userService.Create(user);
            return CreatedAtAction("GetById", new { id = user.Id }, user);
        }
    }
}
