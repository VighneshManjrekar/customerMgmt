using CustomerManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.IServices
{
    public interface IOrderServices
    {
        
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();

        Task<OrderDTO> GetOrderByIdAsync(int id);

        Task<bool> DeleteOrderAsync(int id);

        Task<OrderDTO> UpdateOrderAsync(int id, UpdateOrderDTO updateOrderDTO);

        Task<CreatedOrderDTO> PostOrderAsync(CreateOrderDTO createOrderDTO);
    }
}
