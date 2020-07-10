using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Repositories.Implementations
{
	public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
	{
		private readonly TContext _context;
		private bool disposed = false;
		private Dictionary<Type, object> repositories;
		private IHttpContextAccessor _httpContextAccessor;
	
		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UnitOfWork(TContext context, IHttpContextAccessor httpContextAccessor)		{
			
			_httpContextAccessor = httpContextAccessor;
			_context = context ?? throw new ArgumentNullException(nameof(context));
			
		}

		/// <summary>
		/// Begin Transaction
		/// </summary>
		public void Begin()
		{
			_context.Database.BeginTransaction();
		}

		/// <summary>
		/// Commit Transaction 
		/// </summary>
		public void Commit()
		{
			_context.Database.CommitTransaction();

		}

		/// <summary>
		/// Rollback Transaction
		/// </summary>
		public void Rollback()
		{
			_context.Database.RollbackTransaction();
		}

		/// <summary>
		/// Gets the db context.
		/// </summary>
		/// <returns>The instance of type <typeparamref name="TContext"/>.</returns>
		public TContext DbContext => _context;

		
		/// <summary>
		/// Gets the specified repository for the <typeparamref name="TEntity"/>.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <returns>An instance of type inherited from <see cref="IRepository{TEntity}"/> interface.</returns>
		public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
		{
			if (repositories == null)
			{
				repositories = new Dictionary<Type, object>();
			}

			var type = typeof(TEntity);
			if (!repositories.ContainsKey(type))
			{
				repositories[type] = new Repository<TEntity>(_context, _httpContextAccessor);
			}

			return (IRepository<TEntity>)repositories[type];
		}


		/// <summary>
		/// Saves all changes made in this context to the database.
		/// </summary>
		/// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
		/// <returns>The number of state entries written to the database.</returns>
		public int SaveChanges(bool ensureAutoHistory = false)
		{		

			var result = _context.SaveChanges();			
			return result;
		}

		/// <summary>
		/// Asynchronously saves all changes made in this unit of work to the database.
		/// </summary>
		/// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
		/// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
		public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
		{
			var result = await _context.SaveChangesAsync();			
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
			using (var transaction = _context.Database.BeginTransaction())
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

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <param name="disposing">The disposing.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					// clear repositories
					if (repositories != null)
					{
						repositories.Clear();
					}

					// dispose the db context.
					_context.Dispose();
				}
			}

			disposed = true;
		}
	}
}
