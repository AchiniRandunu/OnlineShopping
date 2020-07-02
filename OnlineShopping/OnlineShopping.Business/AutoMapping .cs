using AutoMapper;
using OnlineShopping.Data.Entities;
using OnlineShopping.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Business
{
	public class AutoMapping :Profile
	{
		public AutoMapping()
		{
			CreateMap<Product, ProductDTO>();
			CreateMap<ProductDTO, Product>();
		}
	}
}
