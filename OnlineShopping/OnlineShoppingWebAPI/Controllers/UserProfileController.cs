using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineShoppingWebAPI.Controllers
{
	/// <summary>
	/// User Profile Controller
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class UserProfileController : ControllerBase
	{
		private readonly ILoginService _loginService;

		public UserProfileController(ILoginService loginService)
		{
			_loginService = loginService;

		}

		/// <summary>
		/// GET : /api/UserProfile
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Authorize]
		public async Task<Object> GetUserProfile()
		{
			try
			{
				string userId = User.Claims.First(c => c.Type == "UserID").Value;
				var result = await _loginService.GetUserProfile(userId);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}


		}
	}
}
