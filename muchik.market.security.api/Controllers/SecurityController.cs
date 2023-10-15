using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using muchik.market.security.application.dto;
using muchik.market.security.application.interfaces;

namespace muchik.market.security.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUserService _securityService;

        public SecurityController(IUserService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_securityService.GetAllUsers());
        }

        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] CreateUserDto userDto)
        {
            _securityService.SignUp(userDto);
            return Ok();
        }

        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody] SignInRequestDto signInRequestDto)
        {
            return Ok(_securityService.SignIn(signInRequestDto));
        }
    }
}
