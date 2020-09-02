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
        Task<IList<PaymentDTO>> GetPaymentsByUserID(string userName);
    }
}
