using System;
namespace BackendSolution.Models
{
	public class PersonRequest
	{
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public Contact contact;
        public Address address;
    
	}
}

