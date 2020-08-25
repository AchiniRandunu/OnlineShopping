using OnlineShopping.DTO;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces
{
    /// <summary>
    /// Checkout service
    /// </summary>
	public interface ICheckoutService
	{
        /// <summary>
        /// Save order
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
		Task<Object> SaveOrder(OrderShippingPaymentDTO orderDto);

	}
}
