using OnlineShopping.DTO;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces
{
	/// <summary>
	/// Registration interface
	/// </summary>
	public interface IRegistrationService
	{
		/// <summary>
		/// User Register method
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<Object> Register(ApplicationUserDTO model);
	}
}
