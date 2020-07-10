using System;
using System.Threading.Tasks;

namespace OnlineShopping.Repositories.Interfaces
{
	/// <summary>
	/// Unit of work interface
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		
		/// <summary>
		/// Begin Transaction
		/// </summary>
		void Begin();

		/// <summary>
		/// Commit Transaction 
		/// </summary>
		void Commit();

		/// <summary>
		/// Rollback Transaction
		/// </summary>
		void Rollback();
	

		/// <summary>
		/// Gets the specified repository for the <typeparamref name="TEntity"/>.
		/// </summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <returns>An instance of type inherited from <see cref="IRepository{TEntity}"/> interface.</returns>
		IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

		/// <summary>
		/// Saves all changes made in this context to the database.
		/// </summary>
		/// <param name="ensureAutoHistory"><c>True</c> if sayve changes ensure auto record the change history.</param>
		/// <returns>The number of state entries written to the database.</returns>
		int SaveChanges(bool ensureAutoHistory = false);

		/// <summary>
		/// Asynchronously saves all changes made in this unit of work to the database.
		/// </summary>
		/// <param name="ensureAutoHistory"><c>True</c> if save changes ensure auto record the change history.</param>
		/// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
		Task<int> SaveChangesAsync(bool ensureAutoHistory = false);



	}
}
