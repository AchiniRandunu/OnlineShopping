using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using Serilog;

namespace OnlineShoppingWebAPI.Controllers
{
    /// <summary>
    /// Payment Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService = null;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Get payment details by user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route ("GetPaymentByUser/{userName}")]
        public ResponseDTO GetPaymentsByUser(string userName)
        {
            var result = _paymentService.GetPaymentsByUserID(userName).Result;
            if (result != null)
            {
                Log.Information("Get Payment details by user completed!");
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
                    Data = "",
                    ErrorDescription = "Get Payment details by user Failed!",
                    Statuscode = HttpStatusCode.BadRequest.ToString(),
                };

        }
    }
}
