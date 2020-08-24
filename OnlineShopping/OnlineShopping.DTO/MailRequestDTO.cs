using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.DTO
{
    public class MailRequestDTO
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public IList<OrderLineItemDTO> BodyProducts { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
