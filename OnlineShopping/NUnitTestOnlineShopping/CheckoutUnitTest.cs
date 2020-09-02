using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using OnlineShopping.Business;
using OnlineShopping.Business.Implementations;
using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;
using OnlineShopping.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.NUnitTest
{
    /// <summary>
    /// Unit test for Checkout service
    /// </summary>
    [TestFixture]
    public class CheckoutUnitTest
    {
        private IMapper mapper;
        private Mock<IOrderRepository> orderRepository;
        private Mock<IOrderLineItemsRepository> orderLineItemsRepository;
        private Mock<IPaymentRepository> paymentRepository;
        private IList<OrderLineItemDTO> orderLineItems;
        [SetUp]
        public void Setup()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            mapper = mockMapper.CreateMapper();
            orderRepository = new Mock<IOrderRepository>();
            orderLineItemsRepository = new Mock<IOrderLineItemsRepository>();
            paymentRepository = new Mock<IPaymentRepository>();
            var user = new ApplicationUser();

        }

        /// <summary>
        /// Test save order
        /// </summary>
        [Test]
        public void Test_Save_Order()
        {
            var applicationUser = new ApplicationUser
            {
                FullName = "qwe rty",
                UserName = "achinirr",
                PasswordHash = "AQAAAAEAACcQAAAAEFhb4f6tea+M5ljLQQv6paGE6/eo+IHQmiD0vlNdhJ66vPRY0rpFdoCW9XoeYm5/DQ==",
                Email = "qwe@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false
            };           

            orderLineItems = new List<OrderLineItemDTO>();
 
            orderLineItems.Add(new OrderLineItemDTO()
            {
                ProductID = 1,
                Price = 25.00,
                Quantity = 2
            });

            orderLineItems.Add(new OrderLineItemDTO()
            {
                ProductID = 2,
                Price = 15.00,
                Quantity = 4
            });

            var orderShippingPaymentDTO = new OrderShippingPaymentDTO
            {
                FullName = "qwe rty",
                PaymentMethod = "qwe rty",
                OrderDate = DateTime.UtcNow,
                PaymentStatus = "Paid",
                ShipAddress = "34c ,Test address ",
                ShippingMethod = "UPS",             
                Email = "qwe@gmail.com",
                PhoneNumber = "0123456789",
                OrderTotalPrice = 568.00,
                OrderStatus = "Completed",
                ZipCode = "10001",
                UserName = "achinirr",
                OrderLineItems = orderLineItems
            };

            var applicationUserlist = new List<ApplicationUser>();
            applicationUserlist.Add(applicationUser);
            var userManager = MockUserManager(applicationUserlist);
            userManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(applicationUser));

            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                ShippedDate = DateTime.UtcNow,
                ShipAddress = orderShippingPaymentDTO.ShipAddress,
                ShippingMethod = orderShippingPaymentDTO.ShippingMethod,
                Email = orderShippingPaymentDTO.Email,
                PhoneNumber = orderShippingPaymentDTO.PhoneNumber,
                TotalPrice = orderShippingPaymentDTO.OrderTotalPrice,
                OrderStatus = orderShippingPaymentDTO.OrderStatus
            };          

            orderRepository.Setup(mr => mr.Save(It.IsAny<Order>())).Returns(order);         

            var orderId = order.Id;
            foreach (var item in mapper.Map<IList<OrderLineItem>>(orderShippingPaymentDTO.OrderLineItems))
            {
                item.OrderID = orderId;
                orderLineItemsRepository.Setup(mr => mr.Save(It.IsAny<OrderLineItem>())).Returns(item);
            }

            var payment = new Payment
            {
                PaidDate = DateTime.UtcNow,
                Description = "",
                TotalPrice = order.TotalPrice,
                PaymentStatus = orderShippingPaymentDTO.PaymentStatus,
                PaymentMethod = orderShippingPaymentDTO.PaymentMethod,
                OrderID = order.Id,
                UserID = ""

            };

            paymentRepository.Setup(mr => mr.Save(It.IsAny<Payment>())).Returns(payment);

            var checkoutService = new CheckoutService(mapper, orderRepository.Object,orderLineItemsRepository.Object,
                paymentRepository.Object,userManager.Object);
            var result = checkoutService.SaveOrder(orderShippingPaymentDTO);

            //Arrest
           Assert.AreEqual( "Successful Saved", result.Result);
        }

       
        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var userStore = new Mock<IUserStore<TUser>>();
            var userManager = new Mock<UserManager<TUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            userManager.Object.UserValidators.Add(new UserValidator<TUser>());
            userManager.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            userManager.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            userManager.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            userManager.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);


            return userManager;
        }
    }
}
