using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.IO;

namespace AuthService.Models
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("MySqlConnection");

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)));
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
