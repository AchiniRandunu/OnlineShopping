using AutoMapper;
using OnlineShopping.Data.Entities;
using OnlineShopping.DTO;

namespace OnlineShopping.Business
{
	/// <summary>
	/// AutoMapping class for mapping of the entities and DTOs
	/// </summary>
	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			CreateMap<Product, ProductDTO>();
			CreateMap<ProductDTO, Product>();
			CreateMap<Order, OrderDTO>();
			CreateMap<OrderDTO, Order>();
			CreateMap<Payment, PaymentDTO>();
			CreateMap<PaymentDTO, Payment>();
			CreateMap<OrderLineItem, OrderLineItemDTO>();
			CreateMap<OrderLineItemDTO, OrderLineItem>();
            CreateMap<OrderLineItemDTO, Order>();
            CreateMap<Order, OrderShippingPaymentDTO>();
		}
	}
}
