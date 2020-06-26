using OnlineShopping.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Business.Interfaces
{
	public interface IProductService
	{
		IList<ProductDTO> GetProducts();
	}
}
