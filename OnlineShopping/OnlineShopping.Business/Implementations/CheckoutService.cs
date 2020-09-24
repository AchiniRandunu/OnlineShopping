using AutoMapper;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Identity;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;
using OnlineShopping.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Implementations
{
    /// <summary>
    /// Checkout Service
    /// </summary>
	public class CheckoutService : ICheckoutService
	{
		private readonly IMapper _mapper = null;
		private readonly IOrderRepository _orderRepository = null;
		private readonly IOrderLineItemsRepository _orderLineItemsRepository = null;
		private readonly IPaymentRepository _paymentRepository = null;
        private readonly UserManager<ApplicationUser> _userManager = null;

		public CheckoutService(IMapper mapper, IOrderRepository orderRepository,
			IOrderLineItemsRepository orderLineItemsRepository ,IPaymentRepository paymentRepository,
			UserManager<ApplicationUser> userManager)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
			_orderLineItemsRepository = orderLineItemsRepository;
			_paymentRepository = paymentRepository;
			_userManager = userManager;
		}

        /// <summary>
        /// Save Order details
        /// </summary>
        /// <param name="orderShippingPaymentDto"></param>
        /// <returns></returns>
		public async Task<object> SaveOrder(OrderShippingPaymentDTO orderShippingPaymentDto)
		{   

            var user = await _userManager.FindByNameAsync(orderShippingPaymentDto.UserName);
            //save order
            var order = new Order
			{
				OrderDate = DateTime.UtcNow,
				ShippedDate = DateTime.UtcNow,// Assumption : products are shipped within the order date.
				ShipAddress = orderShippingPaymentDto.ShipAddress,
				ShippingMethod = orderShippingPaymentDto.ShippingMethod,
				Email = orderShippingPaymentDto.Email,
				PhoneNumber = orderShippingPaymentDto.PhoneNumber,
				TotalPrice = orderShippingPaymentDto.OrderTotalPrice,
				OrderStatus = orderShippingPaymentDto.OrderStatus
                

            };
			 var orderId =_orderRepository.Save(order).Id;
            if (orderShippingPaymentDto.OrderLineItems.Count <= 0)
            {
                throw new InvalidOperationException("Can not save order Line items.");
            }

            else
            {
                //save order line items
                foreach (var item in _mapper.Map<IList<OrderLineItem>>(orderShippingPaymentDto.OrderLineItems))
                {
                    item.OrderID = orderId;
                    _orderLineItemsRepository.Save(item);
                }

            }

            if (!string.IsNullOrEmpty(user.Id))
            {
                //Save payment details            
                var payment = new Payment
                {
                    PaidDate = DateTime.UtcNow,
                    Description = "",
                    TotalPrice = order.TotalPrice,
                    PaymentStatus = orderShippingPaymentDto.PaymentStatus,
                    PaymentMethod = orderShippingPaymentDto.PaymentMethod,
                    OrderID = order.Id,
                    UserID = user.Id

                };
                _paymentRepository.Save(payment);
                throw new InvalidOperationException("Can not save payment details.");
            }
               
                   

            return "Successful Saved";
		}
	}    
}
