using AuthService.Models;

namespace AuthService.Services
{
    public class PersonService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<PersonService> _logger;

        public PersonService(AppDbContext dbContext, ILogger<PersonService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public List<Person> GetAllPersons()
        {
            try
            {
                return _dbContext.Persons.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all persons");
                throw;
            }
        }

        public Person GetPersonById(Guid id)
        {
            try
            {
                return _dbContext.Persons.Find(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting person with ID: {id}");
                throw;
            }
        }

        public void CreatePerson(Person person)
        {
            try
            {
                _dbContext.Persons.Add(person);
                 _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a person");
                throw;
            }
        }

        public void UpdatePerson(Person person)
        {
            try
            {
                _dbContext.Persons.Update(person);
                 _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating person with ID: {person.Id}");
                throw;
            }
        }

        public void DeletePerson(Guid id)
        {
            try
            {
                var person =  _dbContext.Persons.Find(id);
                if (person != null)
                {
                    _dbContext.Persons.Remove(person);
                     _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting person with ID: {id}");
                throw;
            }
        }
    }
}
