using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;


namespace OnlineShopping.Data.Repositories.Implementations
{
    /// <summary>
    /// Account repository
    /// </summary>
	public class AccountRepository : Repository<Account>, IAccountRepository
	{
		private readonly OnlineShoppingDBContext _dbContext;
		public AccountRepository(OnlineShoppingDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
