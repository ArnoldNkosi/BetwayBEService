using AuthService.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PersonService _personService;

        public AccountController(PersonService personService)
        {
            _personService = personService;
        }



        [HttpGet]
        [Route("healthCheck")]
        public IActionResult healthCheck()
        {
            return Ok();
        }


        [HttpGet]
        [Route("GetUser")]

        public IActionResult GetUserDetails(Guid id)
        {
            if (id != null)
            {
                var person = _personService.GetPersonById(id);
                if (person != null) return Ok(person);
                else return Ok("Person not found");
            }

            return BadRequest("id is null");

        }

        [HttpPost]
        [Route("CreateUser")]

        public IActionResult CreateUser(Person person)
        {
            if (person != null)
            {
                _personService.CreatePerson(person);
                return Ok();
            }

            return BadRequest("Person object is null");

        }



        [HttpGet]
        [Route("DeleteUser")]

        public IActionResult DeleteUser(Guid id)
        {
            if (id != null)
            {

                _personService.DeletePerson(id);
                return Ok();

            }

            return BadRequest("id is null");

        }


        [HttpGet]
        [Route("UpdateUser")]

        public IActionResult UpdateUser(Person person)
        {
            if (person != null)
            {
                _personService.UpdatePerson(person);
                return Ok();
            }

            return BadRequest("id is null");

        }
    }
}
