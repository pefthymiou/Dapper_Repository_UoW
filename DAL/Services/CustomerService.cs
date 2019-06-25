using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;

namespace DAL.Services
{
  public class CustomerService : ICustomerService
  {
    private readonly IDbContext _context;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(IDbContext context, ICustomerRepository customerRepository)
    {
      _context = context;
      _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
      return await _customerRepository.GetAllCustomersAsync();
    }

    public async Task<Customer> GetCustomerAsync(Guid customerId)
    {
      var customer = await _customerRepository.GetCustomerAsync(customerId);
      return customer;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
      Customer customer1 = new Customer()
      {
        CustomerId = customer.CustomerId,
        Firstname = customer.Firstname,
        Lastname = customer.Lastname,
        Email = customer.Email,
        Password = customer.Password,
        Address = customer.Address,
        City = customer.City,
        PostalCode = customer.PostalCode,
        Telephone = customer.Telephone
      };
      await _customerRepository.AddCustomerAsync(customer1);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
      Customer customer1 = new Customer()
      {
        CustomerId = customer.CustomerId,
        Address = customer.Address,
        City = customer.City,
        PostalCode = customer.PostalCode,
        Telephone = customer.Telephone
      };

      await _customerRepository.UpdateCustomerAsync(customer1);
    }
  }
}