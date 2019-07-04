using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
  public interface IOrderService
  {
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderAsync(int orderId);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
  }
}
