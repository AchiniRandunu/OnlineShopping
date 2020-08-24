using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
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
        public EmailService(IOptions<MailSettingsDTO> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        /// <summary>
        /// Send Emails
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        public async Task<Object> SendEmailAsync(MailRequestDTO mailRequest)
        {
            double total = 0.0;            

            StringBuilder strHTMLBuilder = new StringBuilder();
            DataTable dt = new DataTable();

            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Sub_Total", typeof(string));


            foreach (var item in mailRequest.BodyProducts)
            {
             
                dt.Rows.Add(item.ProductName, item.Price.ToString(), item.Quantity.ToString(), (item.Quantity * item.Price).ToString());
                total = total + (item.Quantity * item.Price);

            }

            var MailText = ExportDatatableToHtml(dt);            
            MailText = MailText.Replace("[total]", total.ToString());


            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
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
                            Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            message.Attachments.Add(att);
                        }
                    }
                }
            }

           
            message.IsBodyHtml = true;
            message.Body = MailText;   

            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);

            return "Ok";

        }

        /// <summary>
        /// Generate HTML Email view
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        static string ExportDatatableToHtml(DataTable dt)
        {
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<h2>");
            strHTMLBuilder.Append("Online Shopping - Bill Summary");
            strHTMLBuilder.Append("</h2>");
            strHTMLBuilder.Append("<hr/>");
            strHTMLBuilder.Append("<table border='0px'; width= 2000 % '>");
            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");
            }
            strHTMLBuilder.Append("</tr>");

            foreach (DataRow myRow in dt.Rows)
            {
                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }

            strHTMLBuilder.Append("<tr >");
            strHTMLBuilder.Append("<td colspan='3', align='right'>");
            strHTMLBuilder.Append("Tax : Free");
            strHTMLBuilder.Append("</td>");        
            strHTMLBuilder.Append("</tr>");

            strHTMLBuilder.Append("<tr >");
            strHTMLBuilder.Append("<td colspan='3', align='right'>");
            strHTMLBuilder.Append("Delivery : Free");
            strHTMLBuilder.Append("</td>");
            strHTMLBuilder.Append("</tr>");

            strHTMLBuilder.Append("<tr >");
            strHTMLBuilder.Append("<td colspan='3', align='right' >");
            strHTMLBuilder.Append("Total Price : [total]");
            strHTMLBuilder.Append("</td>");
            strHTMLBuilder.Append("</tr>");
          
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");

            string Htmltext = strHTMLBuilder.ToString();
            return Htmltext;
        }
    }   

}
