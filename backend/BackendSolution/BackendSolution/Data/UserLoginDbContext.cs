using System;
using BackendSolution.Models;
using Microsoft.EntityFrameworkCore;
namespace BackendSolution.Data

{
	public class UserLoginDbContext:DbContext
	{
		public UserLoginDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<UserLogin> userLogins { get; set; }
	}
}

