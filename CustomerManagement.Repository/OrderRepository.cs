using CustomerManagement.Data;
using CustomerManagement.DTO;
using CustomerManagement.IRepositories;
using CustomerManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly CustomerManagementDbContext _context;
        public OrderRepository(CustomerManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<IEnumerable<Order>> FindAllAsync()
        {
            try
            {
                var populatedOrder = await _context.Set<Order>()
                                        .Include(u => u.OrderOfUser)
                                            .ThenInclude(r => r.UserRole)
                                        .Include(u => u.OrderOfUser)
                                            .ThenInclude(g => g.UserGender)
                                        .Include(od => od.CurrentOrderDetails)
                                            .ThenInclude(p => p.OrderDetailOfProduct).ToListAsync();
                return populatedOrder;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async override Task<Order> FindByIdAsync(int id)
        {
            try
            {
                var populatedOrder = await _context.Set<Order>()
                                        .Include(u => u.OrderOfUser)
                                            .ThenInclude(r => r.UserRole)
                                        .Include(u => u.OrderOfUser)
                                            .ThenInclude(g => g.UserGender)
                                        .Include(od => od.CurrentOrderDetails)
                                            .ThenInclude(p => p.OrderDetailOfProduct)
                                        .FirstOrDefaultAsync(o => o.OrderId == id);
                if (populatedOrder != null) return populatedOrder;
                throw new Exception($"No order with id:{id}");

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public OrderDTO MapOrders(Order order)
        {
            return new OrderDTO(
                order.OrderTotal,
                order.Discount,
                order.Balance,
                order.BalanceReminder,
                order.StartDate,
                order.EndDate,
                new UserDTO(
                    order.OrderOfUser.UserName,
                    order.OrderOfUser.Phone,
                    order.OrderOfUser.Email,
                    order.OrderOfUser.Address,
                    order.OrderOfUser.UserRole.RoleName,
                    order.OrderOfUser.UserGender.GenderName,
                    order.OrderOfUser.CreatedDate
                ),
                order.CurrentOrderDetails.Select(y => new OrderDetailDTO(
                    y.Quantity,
                    y.ProductId,
                    y.ProductPrice,
                    y.ProdcutSubtotal,
                    y.ProductTotal,
                    y.Discount,
                    y.IGst,
                    y.CGst,
                    y.SGst,
                    y.UTGst,
                    new ProductOrderDetail(
                        y.OrderDetailOfProduct.IsSubscribable,
                        y.OrderDetailOfProduct.ProductName,
                        y.OrderDetailOfProduct.ProductDescription,
                        y.OrderDetailOfProduct.IsActive,
                        y.OrderDetailOfProduct.CreatedDate
                    ),
                    y.StartDate,
                    y.EndDate,
                    y.CreatedDate
                )),
                order.CreatedDate
            );
        }
        public async Task<IDictionary<int, OrderDetail>> GetOrderDetailsOfOrder(int id)
        {
            try
            {
                var orderDetails = await _context.OrderDetails.Include(p => p.OrderDetailOfProduct).Where(od => od.OrderId == id).ToListAsync();
                var orderDictonary = orderDetails.ToDictionary(od => od.OrderDetailsId, p => p);
                return orderDictonary;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

}
