using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Common;
using OnlineShopping.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repositories.Implementations
{
    /// <summary>
    /// Repository
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
            _dbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
