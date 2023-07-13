using BackendSolution.DataObjects;
using BackendSolution.Models;
using BackendSolution.ServiceImpl;
using MySql.Data.MySqlClient;
using System;

namespace BackendSolution.Service
{
    public class PersonService : PersonServiceInterface
    {
        static MySqlConnection connection;

        public void DeletePersonDetails(PersonRequest request)
        {
            // Implementation for deleting person details
        }

        public void SavePersonDetails(PersonRequest request)
        {
            // Implementation for saving person details
        }

        public void UpdatePersonDetails(PersonRequest request)
        {
            // Implementation for updating person details
        }

        public Person SelectPersonDetails(PersonRequest request)
        {
            DbConnection.Connect();





            connection.Close();
            return new Person();




        }
    }
}
