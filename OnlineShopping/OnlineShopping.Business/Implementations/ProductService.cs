using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using OnlineShopping.Repositories.Implementations;
using OnlineShopping.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShopping.Business.Implementations
{
	
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository = null;
		public ProductService(IProductRepository productRepository)
		{
			productRepository = _productRepository;
			
		}
		public IList<ProductDTO> GetProducts()
		{
			return _productRepository.GetAllProducts().Select(v => ObjectConverter.ConvertProductEntityToDTO(v)).ToList();
		}
	}
}
