﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.Data;
using OnlineShopping.Data.Entities;
using OnlineShopping.DTO;
using Serilog;

namespace OnlineShopping.Controllers
{
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
        public IList<ProductDTO> GetAllActiveProducts()
        {
            return _productService.GetProducts();
        }


        
    }
}
