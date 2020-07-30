using OnlineShopping.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineShopping.Data.Common;

namespace OnlineShopping.Data.Repositories.Implementations
{
    /// <summary>
    /// Repository class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
	public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly OnlineShoppingDBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(OnlineShoppingDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<bool> Delete(object id)
        {
            T entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;
            _dbSet.Remove(entity);

            return true;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T Save(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
