using Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Final_Project.DATA
{
	public class AppDbContext : IdentityDbContext<Customer>
	{
		public AppDbContext(DbContextOptions<AppDbContext> s) : base(s)
		{

		}

		public DbSet<Customer> Registers { get; set; }
	}
}