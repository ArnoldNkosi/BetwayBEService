using System;
namespace BackendSolution.Models
{
	public class OTPTokenModel:UserLogin
	{
		public Guid Id { get; set; }
		public string token { get; set; }
		public DateTime createdDateTime { get; set; }
	}
}

