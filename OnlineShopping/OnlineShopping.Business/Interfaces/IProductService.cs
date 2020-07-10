using OnlineShopping.DTO;
using System.Collections.Generic;


namespace OnlineShopping.Business.Interfaces
{
	/// <summary>
	/// Product service interface
	/// </summary>
	public interface IProductService
	{
		/// <summary>
		/// Get Products
		/// </summary>
		/// <returns></returns>
		IList<ProductDTO> GetProducts();
	}
}
