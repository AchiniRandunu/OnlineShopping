using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.Data.Entities;
using OnlineShopping.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Implementations
{
	public class RegistrationService : IRegistrationService
	{
		private UserManager<ApplicationUser> _userManager;	
		private readonly ApplicationSettingsDTO _appSettings;

		public RegistrationService(UserManager<ApplicationUser> userManager,IOptions<ApplicationSettingsDTO> appSettings)
		{
			_userManager = userManager;			
			_appSettings = appSettings.Value;
		}
		public async Task<object> PostApplicationUser(ApplicationUserDTO applicationUserDto)
		{
			var applicationUser = new ApplicationUser()
			{
				UserName = applicationUserDto.UserName,
				Email = applicationUserDto.Email,
				FullName = applicationUserDto.FullName
			};

			try
			{
				var result = await _userManager.CreateAsync(applicationUser, applicationUserDto.Password);
				return (result);
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
