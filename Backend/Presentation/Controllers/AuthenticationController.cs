using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly AuthenticationServices _authenticationService;

        public AuthenticationController(ILogger<AuthenticationController> logger,
                                        AuthenticationServices authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public void Register(string login, string password)
        {
            _authenticationService.RegisterUser(login, password);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public object Login(string login, string password)
        {
            return _authenticationService.Login(login, password);
        }

        [HttpGet("Refreshtoken")]
        [AllowAnonymous]
        public IActionResult Refreshtoken(string token)
        {
            var refreshedToken = _authenticationService.Refreshtoken(token);
            return Ok(new { Token = refreshedToken });
        }

        [HttpPost("AssignRole")]
        [Authorize(Roles = "Admin")]
        public void AssignRole(string username, string role)
        {
            var user = _authenticationService.GetUser(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Role = role;
        }
    }



}
