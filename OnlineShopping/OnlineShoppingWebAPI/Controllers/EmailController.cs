using System;
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
        public async Task<Object> SendMail(MailRequestDTO request)
        {
            try
            {
                var result= await _mailService.SendEmailAsync(request);
                if (result != null)
                {
                    Log.Information("send Email completed!");
                    

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
