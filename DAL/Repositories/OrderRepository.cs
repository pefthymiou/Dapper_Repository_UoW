using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using Dapper;

namespace DAL.Repositories
{
  public class OrderRepository : IOrderRepository
  {
    private readonly IDbContext _dbContext;

    public OrderRepository(IDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    private IDbConnection _connection => _dbContext.UnitOfWork.Transaction.Connection;

    private IDbTransaction _transaction => _dbContext.UnitOfWork.Transaction;

    public async Task AddOrderAsync(Order order)
    {
      string query = @"INSERT INTO Orders (DateCreated, OrderState, CustomerId) 
                      VALUES (@DateCreated, @OrderState, @CustomerId)";

      await _connection.ExecuteAsync(query, param: order, transaction: _transaction, commandType: CommandType.Text);
      _dbContext.Commit();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
      string query = @"SELECT * FROM Orders";
      return await _connection.QueryAsync<Order>(query, transaction: _transaction);
    }

    public async Task<Order> GetOrderAsync(int orderId)
    {
      string query = @"SELECT * FROM Orders WHERE OrderId = @orderId";
      var order = await _connection.QueryFirstOrDefaultAsync<Order>(query, param: new { OrderId = orderId }, transaction: _transaction);
      return order;
    }

    public Task UpdateOrderAsync(Order order)
    {
      throw new NotImplementedException();
    }
  }
}
