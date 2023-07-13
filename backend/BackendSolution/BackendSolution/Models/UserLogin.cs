using System;
using BackendSolution.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.Intrinsics.X86;

namespace BackendSolution.Models
{
	public class UserLogin:Person
	{
		public Guid Id { get; set; }
		public string username { get; set; }
		public string password { get; set; }

	}
}






