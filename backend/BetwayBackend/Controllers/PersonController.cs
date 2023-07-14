
//using Microsoft.AspNetCore.Mvc;
//using BackendSolution.Models;
//using BackendSolution.Services;
//using BetwayBackend.Interfaces;

//namespace BackendSolution.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PersonController : ControllerBase
//    {
//        private readonly PersonService _personService;
//        private readonly IConfiguration _configuration;
//        private readonly IPersonService _ipersonservice;

//        public PersonController(PersonService personService, IConfiguration configuration,IPersonService ipersonService)
//        {
//            _personService = personService;
//            _configuration = configuration;
//            _ipersonservice = ipersonService;
//        }



//        [HttpGet]
//        public ActionResult<IEnumerable<Person>> GetAllPersons()
//        {
//            var persons = _personService.GetAll();
//            return Ok(persons);
//        }

//        [HttpGet("{id}")]
//        public ActionResult<Person> GetPersonById(Guid id)
//        {
//            if (id != null)
//            {
//                IPersonService personService = new PersonService();
//                return Ok(personService.GetById(id));
//            }
//            return BadRequest();

//        }


//        [HttpPost]
//        public ActionResult<Person> AddPerson([FromBody] Person person)
//        {

//            _ipersonservice.Add(person);
//            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdatePerson(Guid id, [FromBody] Person person)
//        {

//            if (person != null)
//            {
//                _ipersonservice.Update(person);
//                return NoContent();

//            }
//            return BadRequest();
        
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeletePerson(Guid id)
//        {
//            var person = _personService.GetById(id);
//            if (person == null)
//            {
//                return NotFound();
//            }

//            _personService.Delete(id);
//            return NoContent();
//        }


//        // Jwt implementation would go here..

//        //[HttpPost("authenticate")]
//        //public IActionResult Authenticate([FromBody] AuthenticationRequest request)
//        //{
//        //    var person = _personService.Authenticate(request.Username, request.Password);

//        //    if (person == null)
//        //    {
//        //        return Unauthorized(new { message = "Invalid username or password" });
//        //    }

//        //    var token = GenerateJwtToken(person);

//        //    return Ok(new { token });
//        //}
//    }
     
//}
