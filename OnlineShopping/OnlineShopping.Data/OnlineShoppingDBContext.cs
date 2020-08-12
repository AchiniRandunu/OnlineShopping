using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Entities;

namespace OnlineShopping.Data
{
	/// <summary>
	/// Online shopping Db context
	/// </summary>
	public class OnlineShoppingDBContext : IdentityDbContext
	{

		public OnlineShoppingDBContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}


		/// <summary>
		/// Related entities
		/// </summary>
		public DbSet<Account> Accounts { get; set; }
		public DbSet<OrderLineItem> OrderLineItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

	}
}




