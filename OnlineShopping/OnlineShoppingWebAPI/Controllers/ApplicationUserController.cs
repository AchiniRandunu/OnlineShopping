using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using Serilog;
using System;
using System.Threading.Tasks;

namespace OnlineShoppingWebAPI.Controllers
{
	/// <summary>
	/// Apllication user controller
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationUserController : ControllerBase
	{

		private readonly ILoginService _loginService = null;
		private readonly IRegistrationService _registrationService = null;

		public ApplicationUserController(ILoginService loginService, IRegistrationService registrationService)
		{
			_loginService = loginService;
			_registrationService = registrationService;

		}

		/// <summary>
		/// POST : /api/ApplicationUser/Register
		/// </summary>
		/// <param name="applicationUserDto"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Register")]
		public async Task<Object> Register(ApplicationUserDTO applicationUserDto)
		{
			var result = await _registrationService.Register(applicationUserDto);
			Log.Information("register completed!");
			return Ok(result);

		}

		/// <summary>
		///  POST : /api/ApplicationUser/Login
		/// </summary>
		/// <param name="loginDto"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Login")]
		public async Task<Object> Login(LoginDTO loginDto)
		{
			var result = await _loginService.Login(loginDto);
			if (result != null)
			{
				Log.Information("Login completed!");
				return Ok(result);

			}

			else
			{
				Log.Information("Login Unsuccessfull!");
				return BadRequest(new { message = "Username or password is incorrect." });
			}


		}
	}
}