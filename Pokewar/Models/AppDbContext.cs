using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Pokewar.Models
{
	internal class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// Replace the connection string with a secure method of configuration
			optionsBuilder.UseMySql(
				"server=localhost;database=Pokewar;user=root;password=;",
				ServerVersion.Parse("8.0.30")
			);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Hash passwords before storing them in the database
			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					Username = "admin",
					Email = "nicky@hotmail.com",
					Password = CreateHashedPassword("123"), // Hashed password
					Role = 1
				},
				new User
				{
					Id = 2,
					Username = "user",
					Email = "",
					Password = CreateHashedPassword("123"), // Hashed password
					Role = 0
				});
		}

		public static string CreateHashedPassword(string password)
		{
			return SecureHasher.Hash(password);
		}

		// Method to verify password using SecureHasher
		public static bool VerifyPassword(string inputPassword, string hashedPassword)
		{
			return SecureHasher.Verify(inputPassword, hashedPassword);
		}
	}
}
