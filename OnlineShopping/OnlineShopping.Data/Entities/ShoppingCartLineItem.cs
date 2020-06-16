using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineShopping.Data.Entities
{
	public class ShoppingCartLineItem
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int ShoppingCartLineItemID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public Product Product { get; set; }	
		public int ShoppingCartID { get; set; }		
		public ShoppingCart ShoppingCart { get; set; }

	}
}
