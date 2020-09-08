using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShopping.Business.Interfaces;
using OnlineShopping.Data.Entities;
using OnlineShopping.Data.Repositories.Interfaces;
using OnlineShopping.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Implementations
{
    /// <summary>
    /// Payment service
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper = null;
        private readonly IPaymentRepository _paymentRepository;
        private readonly UserManager<ApplicationUser> _userManager = null;
        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository,
            UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _userManager = userManager;
        }
        /// <summary>
        /// Get Payment Details By user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IList<PaymentDTO>> GetPaymentsByUserID(string userName)
        {

            var user = await _userManager.FindByNameAsync(userName);
            var res = _paymentRepository.GetAll().Result.ToList()
                .Where(p => p.UserID == user.Id).Select(v => _mapper.Map<PaymentDTO>(v)).ToList();
            return res;

           
        }

        /// <summary>
        /// Get Order Id by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<int> GetOrderIDByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var dto= _paymentRepository.GetAll().Result.ToList()
                .Where(p => p.UserID == user.Id).Select(v => _mapper.Map<PaymentDTO>(v)).LastOrDefault();

            return dto.OrderID;
          
        }
    }
}
