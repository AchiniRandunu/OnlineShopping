using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;


namespace OnlineShoppingWebAPI.Controllers
{
    /// <summary>
    /// Product controller
    /// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService = null;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all the (active) Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllActiveProducts")]
        public IList<ProductDTO> GetAllActiveProducts()
        {
            return _productService.GetProducts();
        }


    }
}
