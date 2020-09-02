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
	}
}
