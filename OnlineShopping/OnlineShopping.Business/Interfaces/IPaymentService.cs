using OnlineShopping.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Interfaces
{
    /// <summary>
    /// Payment service
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Get payments by user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<IList<PaymentDTO>> GetPaymentsByUserID(string userName);
        /// <summary>
        /// Get OrderID by user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<int> GetOrderIDByUserName(string userName);
    }
}
