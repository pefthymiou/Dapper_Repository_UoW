using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
  public interface IOrderRepository
  {
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderAsync(int orderId);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);

  }
}
