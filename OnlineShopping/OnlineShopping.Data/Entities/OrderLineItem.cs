using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineShopping.Data.Entities
{
	public class OrderLineItem
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int OrderLineItemID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public Product Product { get; set; }
		public int OderID { get; set; }
		public Order Order { get; set; }
		
		
	}
}
