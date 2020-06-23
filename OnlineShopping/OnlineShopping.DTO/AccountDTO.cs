using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.DTO
{
	public class AccountDTO
	{
		public int AccountID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BillingAddress { get; set; }
		public string Email { get; set; }
		public int PhoneNumber { get; set; }
	}
}
