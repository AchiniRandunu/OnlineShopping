using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.DTO
{
	public class ProductDTO
	{
		public int ProductID { get; set; }
		public string ProductSKU { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
	}
}
