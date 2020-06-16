using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Data.Entities;

namespace OnlineShopping.Data
{
	public class OnlineShoppingDBContext : DbContext
	{
		public OnlineShoppingDBContext(
			DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
		//entities
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<ShoppingCartLineItem> ShoppingCartLineItems { get; set; }
		public DbSet<OrderLineItem> OrderLineItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }
		public DbSet<User> Users { get; set; }

	}
}




