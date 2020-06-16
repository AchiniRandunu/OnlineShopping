using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineShopping.Data.Entities
{
	public class ShoppingCart
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int ShoppingCartID { get; set; }
		public DateTime CreatedDate { get; set; }	
		public double TotalPrice { get; set; }
		public ICollection<ShoppingCartLineItem> LineItems { get; set; }
	}
}
