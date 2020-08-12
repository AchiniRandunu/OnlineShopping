using OnlineShopping.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineShopping.Data.Entities
{
	/// <summary>
	/// Order entity class
	/// </summary>
	public class Order : IEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ShippedDate { get; set; }
		public string ShipAddress { get; set; }
		public string ShippingMethod { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public double TotalPrice { get; set; }
		public string OrderStatus { get; set; }
		public ICollection<OrderLineItem> OrderLineItems { get; set; }
		public ICollection<Payment> Payments { get; set; }

	}
}
