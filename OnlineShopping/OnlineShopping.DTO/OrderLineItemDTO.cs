using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.DTO
{
	public class OrderLineItemDTO
	{
		public int OrderLineItemID { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
	
	}
}
