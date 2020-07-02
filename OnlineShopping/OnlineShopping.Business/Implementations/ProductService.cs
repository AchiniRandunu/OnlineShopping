using AutoMapper;
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
		private readonly IMapper _mapper = null;
		private readonly IProductRepository _productRepository = null;		
		public ProductService(IMapper mapper,IProductRepository productRepository)
		{
			mapper = _mapper;
			productRepository = _productRepository;
			
		}
		public IList<ProductDTO> GetProducts()
		{
			return _productRepository.GetAllProducts().Select(v => _mapper.Map<ProductDTO>(v)).ToList();
		}
	}
}
