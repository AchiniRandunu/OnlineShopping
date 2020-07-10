using AutoMapper;
using OnlineShopping.Data.Entities;
using OnlineShopping.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Business
{
	/// <summary>
	/// AutoMapping class for mapping of the entities and DTOs
	/// </summary>
	public class AutoMapping :Profile
	{
		public AutoMapping()
		{
			CreateMap<Product, ProductDTO>();
			CreateMap<ProductDTO, Product>();
		}
	}
}
