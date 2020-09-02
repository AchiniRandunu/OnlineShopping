using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using OnlineShopping.Business;
using OnlineShopping.Business.Implementations;
using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.NUnitTest
{
    /// <summary>
    /// Payment unit test
    /// </summary>
    [TestFixture]
    public class PaymentUnitTest
    {
        private IMapper _mapper;
        private Mock<IPaymentRepository> _paymentRepository;
        private IList<Payment> payments;
       
        [SetUp]
        public void Setup()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();            
            _paymentRepository = new Mock<IPaymentRepository>();
            var user = new ApplicationUser();

            payments = new List<Payment>();

            payments.Add(new Payment()
            {
                Id = 1,
                PaidDate = DateTime.Now,
                Description = "Payment test",
                TotalPrice = 500,
                PaymentStatus = "Paid",
                PaymentMethod = "Card",
                OrderID = 2,
                UserID = "166b6509-a701-45c8-96f2-2e59b13c2944"



            });

            payments.Add(new Payment()
            {
                Id = 3,
                PaidDate = DateTime.Now,
                Description = "Payment test",
                TotalPrice = 500,
                PaymentStatus = "Paid",
                PaymentMethod = "Card",
                OrderID = 2,
                UserID = "166b6509-a701-45c8-96f2-2e59b13c2944"

            });
            payments.Add(new Payment()
            {
                Id = 2,
                PaidDate = DateTime.Now,
                Description = "Payment test2",
                TotalPrice = 300,
                PaymentStatus = "Paid",
                PaymentMethod = "Card",
                OrderID = 3,
                UserID = "166b6509-a701-45c8-96f2-2e59b13c2944"

            });


        }

        /// <summary>
        /// Test get payment by user
        /// </summary>
        [Test]
        public void Test_GetPayment_By_User()
        {
            string userName = "achinirr";
            var applicationUser = new ApplicationUser
            {
                FullName = "qwe rty",
                UserName = "achinirr",
                PasswordHash = "AQAAAAEAACcQAAAAEFhb4f6tea+M5ljLQQv6paGE6/eo+IHQmiD0vlNdhJ66vPRY0rpFdoCW9XoeYm5/DQ==",
                Email = "qwe@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                Id = "166b6509-a701-45c8-96f2-2e59b13c2944"
            };


            var applicationUserlist = new List<ApplicationUser>();
            applicationUserlist.Add(applicationUser);
            var userManager = MockUserManager(applicationUserlist);
            userManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(applicationUser));


            _paymentRepository.Setup(a => a.GetAll()).Returns((Task.FromResult(payments.ToList())));
            //Arrange
            var paymentService = new PaymentService(_mapper,_paymentRepository.Object, userManager.Object);
            var result = paymentService.GetPaymentsByUserID(userName);

            //Arrest
            Assert.IsTrue(result.Result.Count!= 0);

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
