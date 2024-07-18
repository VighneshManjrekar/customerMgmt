using CustomerManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.IServices
{
    public interface IPaymentServices
    {
        
        Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync();

        Task<PaymentDTO> GetPaymentByIdAsync(int id);

        Task<bool> DeletePaymentAsync(int id);

        Task<PaymentDTO> UpdatePaymentAsync(int id, UpdatePaymentDTO updatePaymentDTO);

        Task<PaymentDTO> CreatePaymentAsync(PaymentDTO paymentDTO);
    }
}
