using OnlineShopping.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineShopping.Data.Entities
{
	/// <summary>
	/// Product entity
	/// </summary>
	public class Product : IEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		public string ProductSKU { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double  Price { get; set; }
		public string Description { get; set; }
		public string ImageName { get; set; }
		public int CategoryID { get; set; }
		
	}
}
