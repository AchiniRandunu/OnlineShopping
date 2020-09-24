using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using OnlineShopping.Business.Implementations;
using OnlineShopping.Data.Entities;
using OnlineShopping.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.NUnitTest
{
    /// <summary>
    /// Login and Register Unit tests
    /// </summary>
	[TestFixture]
	public class LoginRegisterUnitTest
	{

		private IOptions<ApplicationSettingsDTO> _options;

		[SetUp]
		public void Setup()
		{
			// mock the settings here
			var applicationOptions = new ApplicationSettingsDTO() { JWT_Secret = "1234567890123456", Client_URL = "http://localhost:4200/" };

			_options = Options.Create(applicationOptions);
			var user = new ApplicationUser();

		}

		[TearDown]
		public void Teardown()
		{

		}


		/// <summary>
		/// Login Test
		/// </summary>
		[Test]
		public void Test_Login_Result()
		{
			var loginDto = new LoginDTO()
			{
				UserName = "achinirr",
				Password = "Qweasd@123"

			};

			var applicationUser = new ApplicationUser
			{
				FullName = "qwe rty",
				UserName = "achinirr",
				PasswordHash = "AQAAAAEAACcQAAAAEFhb4f6tea+M5ljLQQv6paGE6/eo+IHQmiD0vlNdhJ66vPRY0rpFdoCW9XoeYm5/DQ==",
				Email = "qwe@gmail.com",
				EmailConfirmed = true,
				LockoutEnabled = false
			};

			var applicationUserlist = new List<ApplicationUser>();
			applicationUserlist.Add(applicationUser);
			var userManager = MockUserManager(applicationUserlist);
			userManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(applicationUser));
			userManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns(Task.FromResult(true));
			userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(applicationUser));
			//Arrange
			var loginService = new LoginService(userManager.Object, _options);
			var result = loginService.Login(loginDto);

			//Arrest
			Assert.AreNotEqual("Username or password is incorrect.", result.Result);

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

		/// <summary>
		/// Register Test
		/// </summary>
		[Test]
		public void Test_Register_Result()
		{
			var applicationDto = new ApplicationUserDTO()
			{
				UserName = "randunu",
				Password = "Qwwe@123",
				Email = "ran@gmail.com",
				FullName = "ran rty",
			};

			var applicationUserList = new List<ApplicationUser>();
			var userManager = MockUserManager(applicationUserList);
			userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<ApplicationUser, string>((x, y) => applicationUserList.Add(x));

			//Arrange
			var registerService = new RegistrationService(userManager.Object, _options);
			var result = registerService.Register(applicationDto);

			//Arrest
			Assert.IsTrue(result.Result != null);

		}


	}
}
