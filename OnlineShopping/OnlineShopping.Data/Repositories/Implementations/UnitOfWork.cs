using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repositories.Implementations
{
	/// <summary>
	/// Unit of work repository
	/// </summary>	
	public class UnitOfWork<TContext> : IUnitOfWork
	{


		private readonly OnlineShoppingDBContext _dbContext;
		public IProductRepository _proudcts = null;
		public IOrderRepository _orders = null;
		public IOrderLineItemsRepository _orderLineItems = null;
		public IAccountRepository _accounts = null;
		public IPaymentRepository _payments = null;

		public UnitOfWork(OnlineShoppingDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IProductRepository Proudcts
		{
			get
			{
				if (_proudcts == null)
					_proudcts = new ProductRepository(_dbContext);
				return _proudcts;
			}
		}

		public IOrderRepository Orders
		{
			get
			{
				if (_orders == null)
					_orders = new OrderRepository(_dbContext);
				return _orders;
			}

			set
			{
				if (_orders == null)
					_orders = new OrderRepository(_dbContext);

			}
		}

		public IOrderLineItemsRepository OrderLineItems
		{
			get
			{
				if (_orderLineItems == null)
					_orderLineItems = new OrderLineItemsRepository(_dbContext);
				return _orderLineItems;
			}

			set
			{
				if (_orderLineItems == null)
					_orderLineItems = new OrderLineItemsRepository(_dbContext);

			}

		}

		public IAccountRepository Accounts
		{
			get
			{
				if (_accounts == null)
					_accounts = new AccountRepository(_dbContext);
				return _accounts;
			}

			set
			{
				if (_accounts == null)
					_accounts = new AccountRepository(_dbContext);
			}

		}

		public IPaymentRepository Payments
		{
			get
			{
				if (_payments == null)
					_payments = new PaymentRepository(_dbContext);
				return _payments;
			}

			set
			{
				if (_payments == null)
					_payments = new PaymentRepository(_dbContext);
			}
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}

		public async Task SaveAsync()
		{
			await _dbContext.SaveChangesAsync();
		}


		/// <summary>
		/// Begin Transaction
		/// </summary>
		public void Begin()
		{
			_dbContext.Database.BeginTransaction();
		}

		/// <summary>
		/// Commit Transaction 
		/// </summary>
		public void Commit()
		{
			_dbContext.Database.CommitTransaction();

		}

		/// <summary>
		/// Rollback Transaction
		/// </summary>
		public void Rollback()
		{
			_dbContext.Database.RollbackTransaction();
		}


		/// <summary>
		/// Saves all changes made in this context to the database.
		/// </summary>
		/// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
		/// <returns>The number of state entries written to the database.</returns>
		public int SaveChanges(bool ensureAutoHistory = false)
		{

			var result = _dbContext.SaveChanges();
			return result;
		}

		/// <summary>
		/// Asynchronously saves all changes made in this unit of work to the database.
		/// </summary>
		/// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
		/// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
		public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
		{
			var result = await _dbContext.SaveChangesAsync();
			return result;
		}

		/// <summary>
		/// Saves all changes made in this context to the database with distributed transaction.
		/// </summary>
		/// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
		/// <param name="unitOfWorks">An optional <see cref="IUnitOfWorkWrite"/> array.</param>
		/// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
		public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false, params IUnitOfWork[] unitOfWorks)
		{
			// TransactionScope will be included in .NET Core v2.0
			using (var transaction = _dbContext.Database.BeginTransaction())
			{
				try
				{
					var count = 0;
					foreach (var unitOfWork in unitOfWorks)
					{
						var uow = unitOfWork as UnitOfWork<DbContext>;
						////uow.DbContext.Database.UseTransaction(transaction.GetDbTransaction());
						count += await uow.SaveChangesAsync(ensureAutoHistory);
					}

					count += await SaveChangesAsync(ensureAutoHistory);

					transaction.Commit();

					return count;
				}
				catch (Exception ex)
				{

					transaction.Rollback();

					throw ex;
				}
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}



	}
}
