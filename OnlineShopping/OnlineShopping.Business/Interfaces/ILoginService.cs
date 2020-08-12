using OnlineShopping.DTO;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces
{
	/// <summary>
	/// Login service interface
	/// </summary>
	public interface ILoginService
	{
		/// <summary>
		/// Login 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<Object> Login(LoginDTO model);

		/// <summary>
		/// Get usesr Profile
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<Object> GetUserProfile(string userId);
	}
}
