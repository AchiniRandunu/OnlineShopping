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
		//private IContextHelper _contextHelper;
		//private IReportingFramework _repofrm;
		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWorkWrite{TContext}"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UnitOfWork(TContext context, IHttpContextAccessor httpContextAccessor)		{
			
			_httpContextAccessor = httpContextAccessor;
			_context = context ?? throw new ArgumentNullException(nameof(context));
			
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public int ExecuteSqlCommand(string sql, params object[] parameters)
		{
			throw new NotImplementedException();
		}

		public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class
		{
			throw new NotImplementedException();
		}

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

		public int SaveChanges(bool ensureAutoHistory = false)
		{
			throw new NotImplementedException();
		}


	}
}
