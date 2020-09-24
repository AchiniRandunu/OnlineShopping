using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using OnlineShopping.Business.Implementations;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using System.Collections.Generic;


namespace OnlineShopping.NUnitTest
{
    /// <summary>
    /// Email unit test
    /// </summary>
    [TestFixture]
    public class EmailUnitTest
    {
        private IOptions<MailSettingsDTO> _options;
        private IList<OrderLineItemDTO> orderLineItems;
        private Mock<IPaymentService> paymentService;
        [SetUp]
        public void setup()
        {
            // mock the settings here
            var emailOptions = new MailSettingsDTO() { Mail= "achi.testforemail@gmail.com",
               
                Password= "Test@123",
                Host="smtp.gmail.com",
                Port = 587};

            _options = Options.Create(emailOptions);
            paymentService = new Mock<IPaymentService>();
        }

        /// <summary>
        /// Test sending email
        /// </summary>
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
                BodyProducts = orderLineItems,
                UserName = "achinirr"
            };            

            //Arrange
            var emailService = new EmailService( _options , paymentService.Object);
            var result = emailService.SendEmailAsync(requestDto);

            //Arrest
            Assert.AreEqual("Ok", result.Result);
        }
    }
}
