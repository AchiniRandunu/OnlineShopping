using System;
using System.Collections.Generic;

namespace OnlineShopping.DTO
{
    /// <summary>
    /// Order Shipping Payment Dto
    /// </summary>
	public class OrderShippingPaymentDTO
	{
		public string FullName { get; set; }
		public string PaymentMethod { get; set; }
		public string PaymentStatus { get; set; }
		public DateTime OrderDate { get; set; }
		public string ShipAddress { get; set; }
		public string ShippingMethod { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public double OrderTotalPrice { get; set; }
		public string OrderStatus { get; set; }
		public string ZipCode { get; set; }
		public IList<OrderLineItemDTO> OrderLineItems { get; set; }
		public string UserName { get; set; }
	}
}
