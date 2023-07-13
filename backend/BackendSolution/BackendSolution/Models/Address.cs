using System;
namespace BackendSolution.Models
{
	public class Address
	{
		private Guid id { get; set; }
		private string country { get; set; }
		private string region { get; set; }
		private string streetName { get; set; }
		private int streetNumber { get; set; }


		public Address()
		{
		}
	}
}

