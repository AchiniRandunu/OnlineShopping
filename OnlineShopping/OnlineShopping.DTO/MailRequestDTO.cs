using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace OnlineShopping.DTO
{
    /// <summary>
    /// Email request Dto
    /// </summary>
    public class MailRequestDTO
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public IList<OrderLineItemDTO> BodyProducts { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
