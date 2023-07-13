using System;
using BackendSolution.Models;
using BackendSolution.Service;
using BackendSolution.ServiceImpl;
using Microsoft.AspNetCore.Mvc;

namespace BackendSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RegisterController:Controller
	{

        [HttpPost]
        public async Task<IActionResult> SelectUser(PersonRequest request)
        {
            if ( request != null)
            {
                PersonServiceInterface personService = new PersonService();
                return Ok(personService.SelectPersonDetails(request));
            }
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> DeletePerson(PersonRequest request)
        {
            if (request != null)
            {
                PersonServiceInterface personService = new PersonService();
                personService.DeletePersonDetails(request);

                return Ok();
            }
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(PersonRequest request)
        {
            if (request != null)
            {
                PersonServiceInterface personService = new PersonService();
                personService.SavePersonDetails(request);
                return Ok();
            }
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePersonDetails(PersonRequest request)
        {
            if (request != null)
            {
                PersonServiceInterface personService = new PersonService();
                personService.UpdatePersonDetails(request);
                return Ok();
            }
            return BadRequest();
        }
    }
}

