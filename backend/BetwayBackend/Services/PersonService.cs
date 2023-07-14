using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BackendSolution.Models;
using BetwayBackend.Interfaces;

namespace BackendSolution.Services
{
    public class PersonService:IPersonService
    {
        private readonly DbContext _dbContext;


        public IEnumerable<Person> GetAll()
        {
            return _dbContext.Set<Person>().ToList();
        }

        public Person GetById(Guid id)
        {
            return _dbContext.Set<Person>().Find(id);
        }

        public void Add(Person person)
        {
            var existingPerson = GetById(person.Id);
            if (existingPerson != null)
            {
                throw new Exception();
            }

            _dbContext.Set<Person>().Add(person);
            _dbContext.SaveChanges();
        }


        public void Update(Person person)
        {
            var existingPerson = GetById(person.Id);
            if (existingPerson == null)
            {
                throw new Exception();
            }
            Update(person);
            _dbContext.Entry(person).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }


        public void Delete(Guid id)
        {
            var person = _dbContext.Set<Person>().Find(id);
            if (person != null)
            {
                _dbContext.Set<Person>().Remove(person);
                _dbContext.SaveChanges();
            }
        }
    }
}
