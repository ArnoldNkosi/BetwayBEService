using System;
using BackendSolution.Models;
namespace BetwayBackend.Interfaces
{
        public interface IPersonService
        {
            IEnumerable<Person> GetAll();
            Person GetById(Guid id);
            void Add(Person person);
            void Update(Person person);
            void Delete(Guid id);
        }

}

