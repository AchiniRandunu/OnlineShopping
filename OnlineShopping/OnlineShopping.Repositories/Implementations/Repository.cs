
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Http;

namespace OnlineShopping.Repositories.Implementations
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        private IHttpContextAccessor _httpContextAccessor;
 
        //private readonly ILogger _logger=null;
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public Repository(DbContext dbContext, IHttpContextAccessor httpContextAccessor)//,ILogger<Repository<TEntity>> logger)
        {
            
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
            //_logger = logger;
        }
        /// <summary>
        /// Get all records based on filter
        /// </summary>
        /// <param name="predicate">Filter as function</param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, bool skipBaseProperties = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!skipBaseProperties)
               // query = Helper.Helper.SetBasePropertiesOnGet(query);

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }



        /// <summary>
        /// Deletes the entity by the specified primary key.
        /// </summary>
        /// <param name="id">The primary key value.</param>
        public void Delete(object id)
        {
            // using a stub entity to mark for deletion
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo.Name).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    Delete(entity);
                }
            }
        }
        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);

		public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true, bool skipBaseProperties = false)
		{
			throw new NotImplementedException();
		}

		public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true, bool skipBaseProperties = false)
		{
			throw new NotImplementedException();
		}

		public IQueryable<TEntity> FromSql(string sql, params object[] parameters)
		{
			throw new NotImplementedException();
		}

		public TEntity Find(params object[] keyValues)
		{
			throw new NotImplementedException();
		}

		public Task<TEntity> FindAsync(params object[] keyValues)
		{
			throw new NotImplementedException();
		}

		public Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public int Count(Expression<Func<TEntity, bool>> predicate = null)
		{
			throw new NotImplementedException();
		}

		public TEntity InsertReturn(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Insert(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Insert(params TEntity[] entities)
		{
			throw new NotImplementedException();
		}

		public void Insert(IEnumerable<TEntity> entities)
		{
			throw new NotImplementedException();
		}

		public Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task InsertAsync(params TEntity[] entities)
		{
			throw new NotImplementedException();
		}

		public Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public void Update(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public TEntity UpdateReturn(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Update(params TEntity[] entities)
		{
			throw new NotImplementedException();
		}

		public void Update(IEnumerable<TEntity> entities)
		{
			throw new NotImplementedException();
		}

		public void Delete(TEntity entity)
		{
			throw new NotImplementedException();
		}
	}


}