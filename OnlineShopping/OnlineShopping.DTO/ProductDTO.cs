
namespace OnlineShopping.DTO
{
	/// <summary>
	/// Product Dto
	/// </summary>
	public class ProductDTO
	{
		public int ProductID { get; set; }
		public string ProductSKU { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public string Description { get; set; }
		public string ImageName { get; set; }
		public int CategoryID { get; set; }
	}
}
