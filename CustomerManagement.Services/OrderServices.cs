using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CustomerManagement.DTO;
using CustomerManagement.IRepositories;
using CustomerManagement.IServices;
using CustomerManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderServices(IMapper _mapper, IOrderRepository _orderRepository, IProductRepository productRepository)
        {
            mapper = _mapper;
            orderRepository = _orderRepository;
            _productRepository = productRepository;
        }

        public async Task<CreatedOrderDTO> PostOrderAsync(CreateOrderDTO createOrderDTO)
        {
            try
            {
                var productIds = createOrderDTO.CurrentOrderDetails.Select(p => p.ProductId).ToList();
                var products = await _productRepository.FetchProductsByIdAsync(productIds);

                Order order = new Order();
                order.Balance = createOrderDTO.Balance;
                order.CurrentOrderDetails = createOrderDTO.CurrentOrderDetails.Select(x => new OrderDetail()
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    ProductPrice = products[x.ProductId].ProductPrice,
                    ProdcutSubtotal = products[x.ProductId].ProductPrice * x.Quantity,
                    ProductTotal = products[x.ProductId].ProductPrice * x.Quantity + products[x.ProductId].IGstRate + products[x.ProductId].CGstRate + products[x.ProductId].SGstRate + products[x.ProductId].UTGstRate,
                    StartDate = x.StartDate != null ? x.StartDate : null,
                    EndDate = x.StartDate != null ? x.StartDate : null,
                    CreatedDate = DateTimeOffset.Now,
                    UpdatedDate = DateTimeOffset.Now,
                    CreatedBy = x.CreatedBy,
                    UpdatedBy = x.CreatedBy
                }).ToList();
                order.OrderTotal = order.CurrentOrderDetails.Sum(p => p.ProductTotal);
                order.Balance = order.OrderTotal;
                order.Discount = order.CurrentOrderDetails.Sum(p => p.Discount);
                order.BalanceReminder = DateTimeOffset.Now;
                order.UserId = createOrderDTO.UserId;
                order.CreatedDate = DateTimeOffset.Now;
                order.UpdatedDate = DateTimeOffset.Now;
                order.CreatedBy = createOrderDTO.CreatedBy;
                order.UpdatedBy = createOrderDTO.UpdatedBy;

                var createdOrder = await orderRepository.CreateAsync(order);

                var mappedOrder = new CreatedOrderDTO
                (
                    createdOrder.OrderTotal,
                    createdOrder.Discount,
                    createdOrder.Balance,
                    createdOrder.BalanceReminder,
                    createdOrder.StartDate,
                    createdOrder.EndDate,
                    createdOrder.CurrentOrderDetails.Select(x => new OrderDetailDTO(
                        x.Quantity,
                        x.ProductId,
                        x.ProductPrice,
                        x.ProdcutSubtotal,
                        x.ProductTotal,
                        x.Discount,
                        x.IGst,
                        x.CGst,
                        x.SGst,
                        x.UTGst,
                        new ProductOrderDetail(
                           products[x.ProductId].IsSubscribable,
                           products[x.ProductId].ProductName,
                           products[x.ProductId].ProductDescription,
                           products[x.ProductId].IsActive,
                           products[x.ProductId].CreatedDate
                        ),
                        x.StartDate,
                        x.EndDate,
                        x.CreatedDate
                    )),
                    createdOrder.CreatedDate
                );
                return mappedOrder;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await orderRepository.FindByIdAsync(id);
            if (order != null)
            {
                var isDeleted = await orderRepository.DeleteAsync(order);
                return isDeleted;
            }
            return false;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            try
            {
                var orders = await orderRepository.FindAllAsync();
                var mappedOrder = orders.Select(x => orderRepository.MapOrders(x));
                return mappedOrder;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            try
            {
                var order = await orderRepository.FindByIdAsync(id);
                if (order != null)
                {
                    var mappedOrder = orderRepository.MapOrders(order);
                    return mappedOrder;
                }
                throw new Exception($"No Order with Id {id}");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OrderDTO> UpdateOrderAsync(int id, UpdateOrderDTO updateOrderDTO)
        {
            try
            {
                var oldOrder = await orderRepository.FindByIdAsync(id);
                var orderDetails = await orderRepository.GetOrderDetailsOfOrder(id);
                if (oldOrder != null)
                {
                    var productsId = orderDetails.Keys.ToList();
                    var oldOrderProductsId = oldOrder.CurrentOrderDetails.Select(p => p.ProductId).ToList();
                    if (productsId != null && oldOrderProductsId != null &&
                    productsId.OrderBy(x => x).SequenceEqual(oldOrderProductsId.OrderBy(x => x)))
                    {
                        // var products = await _productRepository.FetchProductsByIdAsync(productsId);
                        // var updatedProduct = mapper.Map<Order>(updateOrderDTO);
                        Order order = new Order();
                        order.OrderId = updateOrderDTO.OrderId;
                        order.Balance = updateOrderDTO.Balance;

                        order.CurrentOrderDetails = updateOrderDTO.CurrentOrderDetails.Select(x => new OrderDetail()
                        {
                            OrderDetailsId = x.OrderDetailsId,
                            ProductId = x.ProductId,
                            Quantity = x.Quantity,
                            ProductPrice = orderDetails[x.OrderDetailsId].OrderDetailOfProduct.ProductPrice,
                            ProdcutSubtotal = orderDetails[x.OrderDetailsId].OrderDetailOfProduct.ProductPrice * x.Quantity,

                            ProductTotal = orderDetails[x.OrderDetailsId].OrderDetailOfProduct.ProductPrice * x.Quantity +
                            x.IGst != orderDetails[x.OrderDetailsId].OrderDetailOfProduct.IGstRate ? x.IGst : orderDetails[x.OrderDetailsId].OrderDetailOfProduct.IGstRate +
                            x.CGst != orderDetails[x.OrderDetailsId].OrderDetailOfProduct.CGstRate ? x.CGst : orderDetails[x.OrderDetailsId].OrderDetailOfProduct.CGstRate +
                            x.SGst != orderDetails[x.OrderDetailsId].OrderDetailOfProduct.SGstRate ? x.SGst : orderDetails[x.OrderDetailsId].OrderDetailOfProduct.SGstRate +
                            x.UTGst != orderDetails[x.OrderDetailsId].OrderDetailOfProduct.UTGstRate ? x.UTGst : orderDetails[x.OrderDetailsId].OrderDetailOfProduct.UTGstRate,

                            StartDate = orderDetails[x.OrderDetailsId].OrderDetailOfProduct.StartDate,
                            EndDate = orderDetails[x.OrderDetailsId].OrderDetailOfProduct.EndDate,
                            
                            CreatedDate = orderDetails[x.OrderDetailsId].OrderDetailOfProduct.CreatedDate,
                            UpdatedDate = x.UpdatedDate,
                            CreatedBy = orderDetails[x.OrderDetailsId].OrderDetailOfProduct.CreatedBy,
                            UpdatedBy = x.UpdatedBy
                        }).ToList();
                        order.OrderTotal = order.CurrentOrderDetails.Sum(p => p.ProductTotal);
                        order.Balance = order.OrderTotal;
                        order.Discount = order.CurrentOrderDetails.Sum(p => p.Discount);
                        order.BalanceReminder = DateTimeOffset.Now;
                        order.UserId = updateOrderDTO.UserId;
                        order.CreatedDate = oldOrder.CreatedDate;
                        order.UpdatedDate = oldOrder.UpdatedDate;
                        order.CreatedBy = oldOrder.CreatedBy;
                        order.UpdatedBy = updateOrderDTO.UpdatedBy;
                        var createdOrder = await orderRepository.UpdateAsync(order);
                        var updatedOrder = await orderRepository.FindByIdAsync(createdOrder.OrderId);
                        var mappedOrder = orderRepository.MapOrders(updatedOrder);
                        return mappedOrder;
                    }
                    throw new Exception("Invalid Operation: Cannot update product not present in order summary.");
                }
                else
                {
                    throw new InvalidOperationException($"Order with ID {id} not found.");
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
