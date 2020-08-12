using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;


namespace OnlineShopping.Data.Repositories.Implementations
{
	/// <summary>
	/// Product repository
	/// </summary>
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly OnlineShoppingDBContext _dbContext;
		public ProductRepository(OnlineShoppingDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		/// <summary>
		/// Get all products
		/// </summary>
		/// <returns></returns>
		//IQueryable<Product> IProductRepository.GetAllProducts()
		//{			
		//	return _dbContext.Products.AsQueryable();				
		//}
	}
}
