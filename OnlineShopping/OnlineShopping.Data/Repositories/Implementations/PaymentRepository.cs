using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;

namespace OnlineShopping.Data.Repositories.Implementations
{
	public class PaymentRepository : Repository<Payment>, IPaymentRepository
	{
		private readonly OnlineShoppingDBContext _dbContext;
		public PaymentRepository(OnlineShoppingDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}

}
