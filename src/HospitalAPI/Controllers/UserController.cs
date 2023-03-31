using AirplaneTicketingAPI.DTO;
using AirplaneTicketingAPI.Mappers;
using AirplaneTicketingLibrary.Core.Model;
using AirplaneTicketingLibrary.Core.Repository;
using AirplaneTicketingLibrary.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace AirplaneTicketingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
     
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IGenericMapper<User, UserDTO> _mapper;

        public UserController(IUserRepository userRepository,IUserService userService, IGenericMapper<User, UserDTO> userMapper)
        {
            _userService = userService;
            _userRepository= userRepository;
            _mapper = userMapper;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(_mapper.ToDTO(_userService.GetAll().ToList()));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            return Ok(_mapper.ToDTO(_userService.GetById(id)));
        }

        [HttpGet("find/{email}")]
        public ActionResult GetByEmail(string email)
        {
            return Ok(_mapper.ToDTO(_userService.GetByEmail(email)));
        }

        [HttpPost]
        public ActionResult Create(UserDTO userDTO)
        {
            User user = _mapper.ToModel(userDTO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_userRepository.IsUsernameExist(userDTO.Username) == false && _userRepository.IsEmailExist(userDTO.Email) == false)
            {
                _userService.Create(user);
                return CreatedAtAction("GetById", new { id = user.Id }, user);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var token = _userService.Login(userLogin.Email, userLogin.Password);

                if (token == null)
                    return NotFound("User not found");

                return Ok(Content(token.AccessToken, "application/json"));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("whoiam/{token}")]
        public ActionResult GetByToken(string token)
        {
            return Ok(_userService.GetByEmail(token));
        }

    }
}
