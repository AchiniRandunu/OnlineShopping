using Microsoft.Extensions.Options;
using NUnit.Framework;
using OnlineShopping.Business.Implementations;
using OnlineShopping.DTO;
using System.Collections.Generic;


namespace OnlineShopping.NUnitTest
{
    [TestFixture]
    public class EmailUnitTest
    {
        private IOptions<MailSettingsDTO> _options;
        private IList<OrderLineItemDTO> orderLineItems;
        [SetUp]
        public void setup()
        {
            // mock the settings here
            var emailOptions = new MailSettingsDTO() { Mail= "achi.testforemail@gmail.com",
                DisplayName= "Achini Randunu",
                Password= "Test@123",
                Host="smtp.gmail.com",
                Port = 587};

            _options = Options.Create(emailOptions);

        }

        [Test]
        public void Test_Sending_Email()
        {      
            orderLineItems = new List<OrderLineItemDTO>();

            orderLineItems.Add(new OrderLineItemDTO()
            {
                ProductName = "Oven",
                ProductID = 1,
                Price = 25.00,
                Quantity = 2
            });

            orderLineItems.Add(new OrderLineItemDTO()
            {
                ProductName = "Cooker",
                ProductID = 2,
                Price = 15.00,
                Quantity = 4
            });

            var requestDto = new MailRequestDTO
            {
                ToEmail = "achi.testforemail@gmail.com",
                Subject = "Test Sending Email",
                Attachments = null,
                BodyProducts = orderLineItems
            };            

            //Arrange
            var emailService = new EmailService( _options);
            var result = emailService.SendEmailAsync(requestDto);

            //Arrest
            Assert.AreEqual("Ok", result.Result);
        }
    }
}
