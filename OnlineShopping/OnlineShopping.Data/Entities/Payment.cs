using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineShopping.Data.Entities
{
	public class Payment
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int PaymentID { get; set; }
		public DateTime PaidDate { get; set; }	
		public string Description { get; set; }
		public double TotalPrice { get; set; }
		public string PaymentStatus { get; set; }
		public string PaymentMethod { get; set; }
		public Order Order { get; set; }
		public Account Account { get; set; }
	}
}
