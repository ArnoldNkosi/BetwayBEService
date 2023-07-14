
using BackendSolution.Models;
using BackendSolution.Services;
using BetwayBackend.Interfaces;
using BetwayBackend.Request;
using Microsoft.AspNetCore.Mvc;

namespace BetwayBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
      //  private readonly ILoginService _loginService;
 

        private readonly UserLoginService _userLoginService;
       
        public LoginController(UserLoginService loginService)
        { 
            _userLoginService = loginService;
        }



        [HttpPost]
        public ActionResult<Person> AddPerson([FromBody] UserRequest userRequest)
        {
            if (userRequest != null)
            {
                return Ok(_userLoginService.Login(userRequest));
            }
            return BadRequest();
        }

    }
}

