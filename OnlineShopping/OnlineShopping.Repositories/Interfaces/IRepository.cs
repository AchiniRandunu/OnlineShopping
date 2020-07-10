using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShopping.Repositories.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// Changes the table name. This require the tables in the same database.
		/// </summary>
		/// <param name="table"></param>
		/// <remarks>
		/// This only been used for supporting multiple tables in the same model. This require the tables in the same database.
		/// </remarks>
		////void ChangeTable(string table);

		IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, bool skipBaseProperties = false);



		/// <summary>
		/// Gets the first or default entity based on a predicate, orderby delegate and include delegate. This method default no-tracking query.
		/// </summary>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <param name="orderBy">A function to order elements.</param>
		/// <param name="include">A function to include navigation properties</param>
		/// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
		/// <returns>An <see cref="IPagedList{TEntity}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
		/// <remarks>This method default no-tracking query.</remarks>
		TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
								  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
								  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
								  bool disableTracking = true, bool skipBaseProperties = false);

		/// <summary>
		/// Gets the first or default entity based on a predicate, orderby delegate and include delegate. This method default no-tracking query.
		/// </summary>
		/// <param name="selector">The selector for projection.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <param name="orderBy">A function to order elements.</param>
		/// <param name="include">A function to include navigation properties</param>
		/// <param name="disableTracking"><c>True</c> to disable changing tracking; otherwise, <c>false</c>. Default to <c>true</c>.</param>
		/// <returns>An <see cref="IPagedList{TEntity}"/> that contains elements that satisfy the condition specified by <paramref name="predicate"/>.</returns>
		/// <remarks>This method default no-tracking query.</remarks>
		TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
										   Expression<Func<TEntity, bool>> predicate = null,
										   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
										   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
										   bool disableTracking = true, bool skipBaseProperties = false);

		/// <summary>
		/// Finds an entity with the given primary key values. If found, is attached to the context and returned. If no entity is found, then null is returned.
		/// </summary>
		/// <param name="keyValues">The values of the primary key for the entity to be found.</param>
		/// <returns>The found entity or null.</returns>
		TEntity Find(params object[] keyValues);

		

		/// <summary>
		/// Gets the count based on a predicate.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		int Count(Expression<Func<TEntity, bool>> predicate = null);


		/// <summary>
		/// Inserts a new entity synchronously.
		/// </summary>
		/// <param name="entity">The entity to insert.</param>
		void Insert(TEntity entity);		

		/// <summary>
		/// Updates the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Update(TEntity entity);

		TEntity UpdateReturn(TEntity entity);		

		/// <summary>
		/// Deletes the entity by the specified primary key.
		/// </summary>
		/// <param name="id">The primary key value.</param>
		void Delete(object id);

		/// <summary>
		/// Deletes the specified entity.
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		void Delete(TEntity entity);

		
	}
}
