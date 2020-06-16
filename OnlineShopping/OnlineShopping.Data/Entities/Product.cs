using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineShopping.Data.Entities
{
	public class Product
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int ProductID { get; set; }
		public string ProductSKU { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double  Price { get; set; }
		public string Description { get; set; }	
		
	}
}
