using AirplaneTicketingLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;


namespace AirplaneTicketingAPI.Controllers
{
    public class UserController : ControllerBase
    {
     
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(_userService.GetAll());
        }
    }
}
