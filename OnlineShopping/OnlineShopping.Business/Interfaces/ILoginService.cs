using OnlineShopping.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces
{
	public interface ILoginService
	{
		Task<Object> Login(LoginDTO model);
		Task<Object> GetUserProfile(string userId);
	}
}
