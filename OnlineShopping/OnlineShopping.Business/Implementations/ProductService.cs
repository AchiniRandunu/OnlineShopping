using AutoMapper;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.Data.Repositories.Interfaces;
using OnlineShopping.DTO;
using System.Collections.Generic;
using System.Linq;


namespace OnlineShopping.Business.Implementations
{
	/// <summary>
	/// Product service
	/// </summary>
	public class ProductService : IProductService
	{
		private readonly IMapper _mapper = null;
		private readonly IProductRepository _productRepository;

		public ProductService(IMapper mapper, IProductRepository productRepository)
		{
			_mapper = mapper;
			_productRepository = productRepository;
		}

		/// <summary>
		/// Get all active products
		/// </summary>
		/// <returns></returns>
		public IList<ProductDTO> GetProducts()
		{

			return _productRepository.GetAll().Result.ToList()
				.Select(v => _mapper.Map<ProductDTO>(v)).ToList();
		}

		/// <summary>
		/// Get Product by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ProductDTO GetProductByID(int id)
		{
			return _productRepository.GetAll().Result.ToList()
				.Where(p => p.Id == id).Select(v => _mapper.Map<ProductDTO>(v)).FirstOrDefault();
		}
	}
}
