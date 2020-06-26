using OnlineShopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Repositories.Interfaces
{
	public interface IProductRepository
	{
		IQueryable<Product> GetAllProducts();
	}
}
