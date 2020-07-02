using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ILoginService _loginService = null;

        public UserProfileController(ILoginService loginService)
		{
            _loginService = loginService;

        }
        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
			try
			{
                string userId = User.Claims.First(c => c.Type == "UserID").Value;
                var result = await _loginService.GetUserProfile(userId);
                return result;
            }
            catch(Exception ex)
			{
                throw ex;
			}
            

        }
    }
}
