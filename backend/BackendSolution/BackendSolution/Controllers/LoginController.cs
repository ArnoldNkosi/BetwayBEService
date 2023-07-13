using System;
using BackendSolution.Data;
using BackendSolution.Helper;
using BackendSolution.Models;
using BackendSolution.Service;
using BackendSolution.ServiceImpl;
using Microsoft.AspNetCore.Mvc;

namespace BackendSolution.Controllers
{

	[ApiController]
	[Route("api/[controller]")]

	public class LoginController:Controller
	{
		
        [HttpPost]
        public IActionResult LoginRequest(UserLoginRequest loginRequest)
        {
           if(loginRequest!=null)
            {
                LoginServiceInterface loginService = new LoginService();
                if (loginService.LoginCheck(loginRequest))
                    return Ok();
                else return BadRequest();
            }
           return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> SaveUserLogin(UserLoginRequest saveUserRequest)
        {
            if (saveUserRequest != null)
            {
                LoginServiceInterface loginService = new LoginService();
                loginService.SaveLoginDetails(saveUserRequest);

                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult PasswordReset(UserLoginRequest passwordReset)
        {
            if (passwordReset != null)
            {
                LoginServiceInterface loginService = new LoginService();
                loginService.ResetPassword(passwordReset);

                return Ok();
            }
            return BadRequest();
        }

    }
}

