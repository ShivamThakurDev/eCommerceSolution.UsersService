using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if(registerRequest == null)
            {
                return BadRequest("Invalid request");
            }
            AuthenticationResponse? authenticationResponse =  await _usersService.Register(registerRequest);
            if(authenticationResponse == null||authenticationResponse.Sucess == false)
            {
                return BadRequest("Registration failed");
            }
            return Ok(authenticationResponse);
        }
        [HttpPost("login")]
        public async Task<IActionResult?> Login(LoginRequest loginRequest)
        {
            if(loginRequest == null)
            {
                return BadRequest("Invalid request");
            }
            AuthenticationResponse? authenticationResponse =  await _usersService.Login(loginRequest);
            if(authenticationResponse == null||authenticationResponse.Sucess == false)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
    }
}
