using DAL.Context;
using DAL.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly IDbContext _dbContext;

    public CustomerRepository(IDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    private IDbConnection _connection => _dbContext.UnitOfWork.Transaction.Connection;

    private IDbTransaction _transaction => _dbContext.UnitOfWork.Transaction;

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
      string query = @"SELECT * FROM Customers";
      return await _connection.QueryAsync<Customer>(query, transaction: _transaction);
    }

    public async Task<Customer> GetCustomerAsync(Guid customerId)
    {
      string query = @"SELECT * FROM Customers WHERE CustomerId = @customerId";
      var customer = await _connection.QueryFirstOrDefaultAsync<Customer>(query, param: new { CustomerId = customerId }, transaction: _transaction);
      return customer;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
      string query = @"INSERT INTO Customers
                        (CustomerId, Firstname, Lastname, Email, Password, Address, City, PostalCode, Telephone)
                        VALUES(@CustomerId ,@Firstname, @Lastname, @Email, @Password, @Address, @City, @PostalCode, @Telephone)";

      await _connection.ExecuteAsync(query, param: customer, transaction: _transaction, commandType: CommandType.Text);

      _dbContext.Commit();
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
      string query = @"UPDATE Customers SET Address=@Address, City=@City, PostalCode=@PostalCode, Telephone=@Telephone WHERE CustomerId=@CustomerId";

      DynamicParameters parameters = new DynamicParameters();
      parameters.Add("@CustomerId", customer.CustomerId);
      parameters.Add("@Address", customer.Address);
      parameters.Add("@City", customer.City);
      parameters.Add("@PostalCode", customer.PostalCode);
      parameters.Add("@Telephone", customer.Telephone);

      await _connection.ExecuteAsync(query, param: parameters, transaction: _transaction, commandType: CommandType.Text);

      _dbContext.Commit();
    }
  }
}
