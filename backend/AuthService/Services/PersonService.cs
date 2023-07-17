using AuthService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            try
            {
                return await _dbContext.Persons.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all persons");
                throw;
            }
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Persons.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting person with ID: {id}");
                throw;
            }
        }

        public async Task CreatePersonAsync(Person person)
        {
            try
            {
                _dbContext.Persons.Add(person);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a person");
                throw;
            }
        }

        public async Task UpdatePersonAsync(Person person)
        {
            try
            {
                _dbContext.Persons.Update(person);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating person with ID: {person.Id}");
                throw;
            }
        }

        public async Task DeletePersonAsync(int id)
        {
            try
            {
                var person = await _dbContext.Persons.FindAsync(id);
                if (person != null)
                {
                    _dbContext.Persons.Remove(person);
                    await _dbContext.SaveChangesAsync();
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
