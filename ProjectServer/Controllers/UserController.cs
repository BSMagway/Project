using Microsoft.AspNetCore.Mvc;
using ProjectCommon.Models.Authentication;
using ProjectServer.Interfaces.Service;

namespace ProjectServer.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (_userService.Register(request))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = _userService.Login(request);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
