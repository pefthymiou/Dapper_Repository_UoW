using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;

namespace DAL.Services
{
  public class OrderService : IOrderService
  {
    private readonly IDbContext _context;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IDbContext context, IOrderRepository orderRepository)
    {
      _context = context;
      _orderRepository = orderRepository;
    }
    public async Task AddOrderAsync(Order order)
    {
      Order order1 = new Order()
      {
        DateCreated = DateTime.Now,
        OrderState = "New", //TODO Make OrderState enum
        CustomerId = order.CustomerId
      };
      await _orderRepository.AddOrderAsync(order1);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
      return await _orderRepository.GetAllOrdersAsync();
    }

    public async Task<Order> GetOrderAsync(int orderId)
    {
      var order = await _orderRepository.GetOrderAsync(orderId);
      return order;
    }

    public Task UpdateOrderAsync(Order order)
    {
      throw new NotImplementedException();
    }
  }
}
