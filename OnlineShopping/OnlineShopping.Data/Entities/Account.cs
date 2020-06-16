using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineShopping.Data.Entities
{
	public class Account
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int AccountID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BillingAddress { get; set; }
		public string Email { get; set; }
		public int PhoneNumber { get; set; }		

		public ICollection<Order> Orders { get; set; }
		public ICollection<Payment> Payments { get; set; }
	}
}
