using AutoMapper;
using Moq;
using NUnit.Framework;
using OnlineShopping.Business;
using OnlineShopping.Business.Implementations;
using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace NUnitTestOnlineShopping
{
	/// <summary>
	/// Product Test 
	/// </summary>
	[TestFixture]
	public class ProductTests
	{
		private Mock<IProductRepository> productRepository;
		private IMapper mapper;
		private IList<Product> products;

		[SetUp]
		public void Setup()
		{
			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapping());
			});
			mapper = mockMapper.CreateMapper();
			productRepository = new Mock<IProductRepository>();
			products = new List<Product>();
			products.Add(new Product()
			{
				Id = 1,
				ProductSKU = "001",
				ProductName = "Cooker",
				Quantity = 100,
				Price = 45.00,
				Description = "Good",
				ImageName = "Cooker.jpg",
				CategoryID = 1
			});

			products.Add(new Product()
			{
				Id = 2,
				ProductSKU = "002",
				ProductName = "Toaster",
				Quantity = 100,
				Price = 35.00,
				Description = "Good",
				ImageName = "Toaster.jpg",
				CategoryID = 1
			});

			products.Add(new Product()
			{
				Id = 3,
				ProductSKU = "003",
				ProductName = "FlowerVass",
				Quantity = 200,
				Price = 15.00,
				Description = "Beautiful",
				ImageName = "FlowerVass.jpg",
				CategoryID = 2
			});

		}

		[TearDown]
		public void Teardown()
		{
			//product.Dispose();
		}

		/// <summary>
		/// Get All Product test
		/// </summary>
		[Test]
		public void Test_GetProducts()
		{
			//Act
			productRepository.Setup(a => a.GetAllProducts()).Returns(products.AsQueryable());

			//Arrange
			var productService = new ProductService(mapper, productRepository.Object);
			var productList = productService.GetProducts();

			//Arrest
			Assert.IsTrue(productList.Count == 3);
		}

		/// <summary>
		/// Get Product by ID Test
		/// </summary>
		[Test]
		public void Test_GetProductByID()
		{
			//Act
			var id = 1;
			productRepository.Setup(a => a.GetAllProducts()).Returns(products.AsQueryable());

			//Arrange
			var productService = new ProductService(mapper, productRepository.Object);
			var product = productService.GetProductByID(id);

			//Arrest
			Assert.AreEqual("Cooker", product.ProductName);

		}
	}
}