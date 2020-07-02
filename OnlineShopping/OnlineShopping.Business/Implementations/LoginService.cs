using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.Data.Entities;
using OnlineShopping.DTO;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;





namespace OnlineShopping.Business.Implementations
{
	public class LoginService : ILoginService
	{
        private UserManager<ApplicationUser> _userManager;     
        private readonly ApplicationSettingsDTO _appSettings;

        public LoginService(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettingsDTO> appSettings)
        {
            _userManager = userManager;           
            _appSettings = appSettings.Value;
        }

        public async Task<object> Login(LoginDTO loginDto)
		{
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return (new { token });
            }
            else
                return(new { message = "Username or password is incorrect." });
        }

		public async Task<object> GetUserProfile(string userId)
		{           
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
	}
	
}
