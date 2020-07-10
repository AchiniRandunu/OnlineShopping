﻿using OnlineShopping.Data.Entities;
using System.Linq;


namespace OnlineShopping.Repositories.Interfaces
{
	/// <summary>
	/// Product Repository interface
	/// </summary>
	public interface IProductRepository
	{
		/// <summary>
		/// Get all Products
		/// </summary>
		/// <returns></returns>
		IQueryable<Product> GetAllProducts();
	}
}
