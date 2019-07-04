using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
      _orderService = orderService;
    }

    [HttpGet]
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
      return await _orderService.GetAllOrdersAsync();
    }

    [HttpGet("{id}")]
    public async Task<Order> GetOrder(int orderId)
    {
      return await _orderService.GetOrderAsync(orderId);
    }

    [HttpPost]
    [Route("AddOrder")]
    public async Task AddOrder([FromBody]Order order)
    {
      await _orderService.AddOrderAsync(order);
    }

    [HttpPut]
    [Route("UpdateOrder")]
    public async Task UpdateOrder([FromBody]Order order)
    {
      throw new NotImplementedException();
    }
  }
}