using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;


namespace OnlineShopping.Data.Repositories.Implementations
{
	public class OrderLineItemsRepository : Repository<OrderLineItem>, IOrderLineItemsRepository
	{
		private readonly OnlineShoppingDBContext _dbContext;
		public OrderLineItemsRepository(OnlineShoppingDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}


