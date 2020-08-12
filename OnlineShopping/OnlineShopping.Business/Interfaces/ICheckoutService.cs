using OnlineShopping.DTO;
using System.Threading.Tasks;
namespace OnlineShopping.Business.Interfaces
{
	public interface ICheckoutService
	{
		Task<object> SaveOrder(OrderShippingPaymentDTO orderDto);

	}
}
