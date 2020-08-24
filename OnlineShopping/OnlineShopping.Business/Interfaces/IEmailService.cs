using OnlineShopping.DTO;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces
{
    /// <summary>
    /// Emailservice
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sending Email
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        Task<Object> SendEmailAsync(MailRequestDTO mailRequest);
        
    }
}
