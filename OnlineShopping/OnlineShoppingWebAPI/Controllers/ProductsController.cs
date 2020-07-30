using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        Serilog.ILogger _logger = null;
        public ProductsController(IProductService productService, Serilog.ILogger logger)
        {
            _productService = productService;
            _logger = logger;
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
                _logger.Information("Get All Prodcuts completed!");                
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
                _logger.Information("Get Prodcut by ID completed!");
                return new ResponseDTO()
                {
                    Data = productDto,
                    ErrorDescription = "",
                    Statuscode = "",
                };
               
                
            }
			else
			{
                _logger.Error("Get Prodcut by ID Failed!");
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
