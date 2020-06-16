using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineShopping.Data.Entities
{
	public class Customer
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int CustomerID { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public int PhoneNumber { get; set; }

		public int AccountID { get; set; }
		public Account Account { get; set; }


	}
}
