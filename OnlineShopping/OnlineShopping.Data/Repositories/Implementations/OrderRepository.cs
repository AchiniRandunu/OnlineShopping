using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;


namespace OnlineShopping.Data.Repositories.Implementations
{
    /// <summary>
    /// Order repository
    /// </summary>
	public class OrderRepository : Repository<Order>, IOrderRepository
	{
		private readonly OnlineShoppingDBContext _dbContext;
		public OrderRepository(OnlineShoppingDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
