using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;

namespace OnlineShopping.Controllers
{
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

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
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

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<Object> Login(LoginDTO loginDto)
        {
			try
			{
                var token = await _loginService.Login(loginDto); 
                if(token!= null)
                    return Ok(new { token });
                else
                    return BadRequest(new { message = "Username or password is incorrect." });

            }
            catch(Exception ex)
			{
                throw ex;
               

            }               
           
                
        }
    }
}