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
        public async Task<IActionResult> healthCheck()
        {
            return Ok();
        }


        [HttpGet]
        [Route("GetUser")]

        public async Task<IActionResult> GetUserDetails()
        {
            var person = new List<Person>
            { new Person { Id = 1,Name="Arnold",surname="Nkosi", Address= new Address{Country="South Africa",PostalCode="2196",City="Johannesburg",Region="Gauteng" },Contact=new Contact{Email="arnoldNkosi97@gmail.com"}}};

            return Ok(person);
        }

        [HttpPost]
        [Route("CreateUser")]

        public async Task<IActionResult> CreateUser(Person person)
        {
            if (person != null)
            {
                _personService.CreatePersonAsync(person);
                return Ok();
            }

            return BadRequest("Person object is null");

        }



        [HttpGet]
        [Route("DeleteUser")]

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (id != null)
            {

                _personService.DeletePersonAsync(id);
                return Ok();

            }

            return BadRequest("id is null");

        }


        [HttpGet]
        [Route("UpdateUser")]

        public async Task<IActionResult> UpdateUser(Person person)
        {
            if (person != null)
            {
                _personService.UpdatePersonAsync(person);
                return Ok();
            }

            return BadRequest("id is null");

        }
    }
}
