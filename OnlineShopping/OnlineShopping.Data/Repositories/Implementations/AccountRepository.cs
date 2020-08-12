using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;


namespace OnlineShopping.Data.Repositories.Implementations
{
	public class AccountRepository : Repository<Account>, IAccountRepository
	{
		private readonly OnlineShoppingDBContext _dbContext;
		public AccountRepository(OnlineShoppingDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
