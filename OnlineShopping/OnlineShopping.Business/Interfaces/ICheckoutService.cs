using OnlineShopping.DTO;
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
		Task<object> SaveOrder(OrderShippingPaymentDTO orderDto);

	}
}
