using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Data.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineShopping.Data
{
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

	
		//entities
		public DbSet<Account> Accounts { get; set; }		
		public DbSet<OrderLineItem> OrderLineItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Product> Products { get; set; }	
		//public DbSet<User> Users { get; set; }

	}
}




