using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;
using System.Linq;


namespace OnlineShopping.Data.Repositories.Implementations
{
	/// <summary>
	/// Product repository
	/// </summary>
	public class ProductRepository : IProductRepository
	{
		private IUnitOfWork _unitOfWork = null;


		public ProductRepository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		/// <summary>
		/// Get all products
		/// </summary>
		/// <returns></returns>
		public IQueryable<Product> GetAllProducts()
		{
			return _unitOfWork.GetRepository<Product>().GetAll();
		}

	}
}
