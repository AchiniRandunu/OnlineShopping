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
        /// <summary>
        /// convert DTO to Entity
        /// </summary>
        /// <param name="dtoItem"></param>
        /// <returns></returns>
        public static Product ConvertProductDTOToEntity(ProductDTO dtoItem)
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
        /// <summary>
        /// Convert Entity to DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ProductDTO ConvertProductEntityToDTO(Product entity)
        {
            ProductDTO dtoItem = new ProductDTO();
            if (entity != null)
            {
                dtoItem.ProductID = entity.ProductID;
                dtoItem.ProductName = entity.ProductName;
                dtoItem.ProductSKU = entity.ProductSKU;
                dtoItem.Quantity = entity.Quantity;
                dtoItem.Price = entity.Price;
                dtoItem.Description = entity.Description;

            }

            return dtoItem;
        }
    }
}
