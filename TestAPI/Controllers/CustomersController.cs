using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
      _customerService = customerService;
    }

    [HttpGet]
    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
      return await _customerService.GetAllCustomersAsync();
    }

    [HttpGet("{id}")]
    public async Task<Customer> GetCustomer(Guid customerId)
    {
      return await _customerService.GetCustomerAsync(customerId);
    }

    [HttpPost]
    public async Task AddCustomer([FromBody]Customer customer)
    {
      await _customerService.AddCustomerAsync(customer);
    }
  }
}