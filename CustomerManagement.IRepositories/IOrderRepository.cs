using CustomerManagement.DTO;
using CustomerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.IRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        OrderDTO MapOrders (Order order);
        Task <IDictionary<int,OrderDetail>> GetOrderDetailsOfOrder(int id);
    }
}
