using System;

namespace OnlineShopping.DTO
{
	/// <summary>
	/// Order Dto
	/// </summary>
	public class OrderDTO
	{
		public int OrderID { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ShippedDate { get; set; }
		public string ShipAddress { get; set; }
		public string ShippingMethod { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public double TotalPrice { get; set; }
		public string OrderStatus { get; set; }
	}
}
