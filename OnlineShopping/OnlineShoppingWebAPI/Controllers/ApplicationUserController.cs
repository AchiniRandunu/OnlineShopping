using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;

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
        public async Task<Object> PostApplicationUser(ApplicationUserDTO applicationUserDto)
        {
            try
            {
                var result = await _registrationService.PostApplicationUser(applicationUserDto);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        ///  POST : /api/ApplicationUser/Login
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]       
        public async Task<Object> Login(LoginDTO  loginDto)
        {
            try
            {               
                var result = await _loginService.Login(loginDto);
                if (result != null)
                {                    
                    return Ok( result);
                }
                    
                else
                    return BadRequest(new { message = "Username or password is incorrect." });

            }
            catch (Exception ex)
            {
                throw ex;


            }

        }
    }
}