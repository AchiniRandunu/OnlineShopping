using OnlineShopping.Data.Entities;
using System.Linq;


namespace OnlineShopping.Data.Repositories.Interfaces
{
	/// <summary>
	/// Product Repository interface
	/// </summary>
	public interface IProductRepository:IRepository<Product>
	{
		/// <summary>
		/// Get all Products
		/// </summary>
		/// <returns></returns>
		IQueryable<Product> GetAllProducts();

		
	}
}
