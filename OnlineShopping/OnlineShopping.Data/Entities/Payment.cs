using Microsoft.AspNetCore.Identity;
using OnlineShopping.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineShopping.Data.Entities
{
	/// <summary>
	/// Payment entity
	/// </summary>
	public class Payment : IEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		public DateTime PaidDate { get; set; }
		public string Description { get; set; }
		public double TotalPrice { get; set; }
		public string PaymentStatus { get; set; }
		public string PaymentMethod { get; set; }
		public int OrderID { get; set; }
		public string UserID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }

        [ForeignKey(nameof(UserID))]
        public IdentityUser IdentityUser { get; set; }
    }
}
