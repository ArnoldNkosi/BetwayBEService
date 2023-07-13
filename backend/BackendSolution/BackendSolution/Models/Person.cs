using System;
namespace BackendSolution.Models
{
	public class Person
	{

		private Guid Id { get; set; }
		private string name { get; set; }
		private string surname { get; set; }
		private int age { get; set; }
		private string gender{get;set;}
		private Contact contact;
		private Address address;

	}
}

