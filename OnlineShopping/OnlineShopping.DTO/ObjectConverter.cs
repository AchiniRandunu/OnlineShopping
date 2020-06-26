using OnlineShopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace OnlineShopping.DTO
{
	/// <summary>
	/// convert entity to DTO
	/// </summary>
	public class ObjectConverter
	{
        public static Product ConvertDGActionsDTOToEntity(ProductDTO dtoItem)
        {
            Product entity = new Product();
            if (dtoItem != null)
            {
                entity.ProductID = dtoItem.ProductID;
                entity.ProductName = dtoItem.ProductName;
                entity.ProductSKU = dtoItem.ProductSKU;
                entity.Quantity = dtoItem.Quantity;
                entity.Price = dtoItem.Price;
                entity.Description = dtoItem.Description;               
           
            }

            return entity;
        }
    }
}
