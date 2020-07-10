using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineShopping.Data.Entities
{
	/// <summary>
	/// Order Line Items entity
	/// </summary>
	public class OrderLineItem
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int OrderLineItemID { get; set; }	
		public int Quantity { get; set; }
		public double Price { get; set; }
		public Product Product { get; set; }		
		public Order Order { get; set; }
		
		
	}
}
