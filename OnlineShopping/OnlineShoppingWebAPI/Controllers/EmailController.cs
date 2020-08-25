using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using Serilog;

namespace OnlineShoppingWebAPI.Controllers
{
    /// <summary>
    /// Email Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _mailService;
        public EmailController(IEmailService mailService)
        {
            _mailService = mailService;
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SendEmail")]
        public ResponseDTO SendMail(MailRequestDTO request)
        {
            var result =  _mailService.SendEmailAsync(request);
            if (result != null)
            {
                Log.Information("Sending Bill is completed!");
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
                    ErrorDescription = "Sending Bill is Failed!",
                    Statuscode = HttpStatusCode.BadRequest.ToString(),
                };

        }
            
    }
}
