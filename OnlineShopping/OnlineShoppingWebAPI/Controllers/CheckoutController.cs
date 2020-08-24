using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using Serilog;
using System.Net;

namespace OnlineShoppingWebAPI.Controllers
{
    /// <summary>
    /// Checkout Controller
    /// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class CheckoutController : ControllerBase
	{
		private readonly ICheckoutService _checkoutService = null;
		public CheckoutController(ICheckoutService checkoutService)
		{
			_checkoutService = checkoutService;
		}

		/// <summary>
		/// Save order
		/// </summary>
		/// <param name="orderDTO"></param>
		/// <returns></returns>
		[HttpPost]		
		public ResponseDTO SaveOrder(OrderShippingPaymentDTO orderShippingPaymentDTO)
		{
			var result = _checkoutService.SaveOrder(orderShippingPaymentDTO);
			if (result != null)
			{
				Log.Information("Get All Prodcuts completed!");
				return new ResponseDTO()
				{
					Data = result,
					ErrorDescription = "",
					Statuscode = "",
				};
			}
			else
				return new ResponseDTO()
				{
					Data = "Failed",
					ErrorDescription = "Data not Found",
					Statuscode = HttpStatusCode.BadRequest.ToString(),
				};
		}


	}
}
