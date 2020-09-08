using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Implementations
{
    /// <summary>
    /// Email service
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly MailSettingsDTO _mailSettings;
        private readonly IPaymentService _paymentService;
        public EmailService(IOptions<MailSettingsDTO> mailSettings, IPaymentService paymentService)
        {
            _mailSettings = mailSettings.Value;
            _paymentService = paymentService;
        }

        /// <summary>
        /// Send Emails
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        public async Task<Object> SendEmailAsync(MailRequestDTO mailRequest)
        {

            var mailBody = GetMailBody(mailRequest);
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail);
            message.To.Add(new MailAddress(mailRequest.ToEmail));
            message.Subject = mailRequest.Subject;
            if (mailRequest.Attachments != null)
            {
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            Attachment attachment = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            message.Attachments.Add(attachment);
                        }
                    }
                }
            }

            message.IsBodyHtml = true;
            message.Body = mailBody;

            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.UserName, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);

            return "Ok";

        }

        private string GetMailBody(MailRequestDTO mailRequest)
        {
            var absolutePath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
            var templateFilePath = Path.Combine(absolutePath, "BillEmailTemplate.html");
            var mailBody = string.Empty;
            using (var streamReader = new StreamReader(templateFilePath))
                mailBody = streamReader.ReadToEnd();

            var orderId = _paymentService.GetOrderIDByUserName(mailRequest.UserName).Result;
            double total = 0.0;
            mailBody = mailBody.Replace("{#OrderID}", orderId.ToString("D8"));
            var products = string.Empty;

            foreach (var item in mailRequest.BodyProducts)
            {
                var cost = (item.Quantity * item.Price).ToString("0.00");
                products += $@"<tr>
                                        <td width='75%' align='left' style='font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 15px 10px 5px 10px;'> {item.ProductName} ({item.Quantity}) </td>
                                        <td width='25%' align='left' style='font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 15px 10px 5px 10px;'> ${cost} </td>
                                  </tr>";
                total = total + (item.Quantity * item.Price);
            }
            mailBody = mailBody.Replace("{#Products}", products);
            mailBody = mailBody.Replace("{#TotalCost}", total.ToString("0.00"));
            return mailBody;
        }
        
    }

}
