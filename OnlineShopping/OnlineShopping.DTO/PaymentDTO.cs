using System;

namespace OnlineShopping.DTO
{
	/// <summary>
	/// Payment dto
	/// </summary>
	public class PaymentDTO
	{
		public int Id { get; set; }
		public DateTime PaidDate { get; set; }
		public string Description { get; set; }
		public double TotalPrice { get; set; }
		public string PaymentStatus { get; set; }
		public string PaymentMethod { get; set; }
        public int OrderID { get; set; }
    }
}
