using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.Data.Entities;
using OnlineShopping.DTO;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Implementations
{
	/// <summary>
	///User Registration service
	/// </summary>
	public class RegistrationService : IRegistrationService
	{
		private UserManager<ApplicationUser> _userManager;	
		private readonly ApplicationSettingsDTO _appSettings;

		public RegistrationService(UserManager<ApplicationUser> userManager,IOptions<ApplicationSettingsDTO> appSettings)
		{
			_userManager = userManager;			
			_appSettings = appSettings.Value;
		}

		/// <summary>
		/// Register method
		/// </summary>
		/// <param name="applicationUserDto"></param>
		/// <returns></returns>
		public async Task<object> Register(ApplicationUserDTO applicationUserDto)
		{
			var applicationUser = new ApplicationUser()
			{
				UserName = applicationUserDto.UserName,
				Email = applicationUserDto.Email,
				FullName = applicationUserDto.FullName
			};
			
			var result = await _userManager.CreateAsync(applicationUser, applicationUserDto.Password);
			return (result);
			
		}
	}
}
