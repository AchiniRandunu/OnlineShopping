using OnlineShopping.Data.Entities;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Repositories.Implementations
{
	public class ProductRepository : IProductRepository
	{
		private IUnitOfWork _unitOfWork = null;


		public ProductRepository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IQueryable<Product> GetAllProducts()
		{
			return _unitOfWork.GetRepository<Product>().GetAll();
		}
	}
}
