using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.DTO;
using Serilog;

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
        public ResponseDTO GetAllActiveProducts()
        {
            var productDto = _productService.GetProducts();
            if(productDto.ToList().Count>0)
			{
                Log.Information("Get All Prodcuts completed!");
                return new ResponseDTO()
                {
                    Data = productDto,
                    ErrorDescription = "",
                    Statuscode = "",
                };
            }
            else
                return new ResponseDTO()
                {
                    Data = null,
                    ErrorDescription = "Data not Found",
                    Statuscode = HttpStatusCode.BadRequest.ToString(),
                };

        }

        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductById/{productId}")]
        public ResponseDTO GetProductById(int productId)
        {
            var productDto = _productService.GetProductByID(productId);
            if (productDto != null)
            {
                Log.Information("Get Prodcut by ID completed!");
                return new ResponseDTO()
                {
                    Data = productDto,
                    ErrorDescription = "",
                    Statuscode = "",
                };
               
                
            }
			else
			{
                Log.Information("Get Prodcut by ID Failed!");
                return new ResponseDTO()
                {
                    Data = null,
                    ErrorDescription = "Data not Found",
                    Statuscode = HttpStatusCode.BadRequest.ToString(),
                };

            }
        }

    }
}
