using AuthService.Requests;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpPost]
        [Route("CreateLogin")]
        public IActionResult CreateLogin(LoginRequest request)
        {
            if (request != null)
            {
                _loginService.CreateLogin(request);
                    return Ok("login added");
            }

            return BadRequest("Request is null");
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequest request)
        {
            if (request != null)
            {
                if (_loginService.LoginAttempt(request))
                    return Ok();
                else
                    return BadRequest("LOGIN DETAILS MISMATCH");
            }

            return BadRequest("Request is null");
        }

        [HttpGet]
        [Route("PasswordReset")]
        public IActionResult PasswordReset(string username)
        {
            if (username != null)
            {
                if (_loginService.PasswordReset(username))
                    return Ok("OTP Sent to email");
                else
                    return BadRequest("Failed to reset password");
            }

            return BadRequest("Username is null");
        }
    }
}
