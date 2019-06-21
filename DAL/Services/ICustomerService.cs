﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
  public interface ICustomerService
  {
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer> GetCustomerAsync(Guid customerId);
    Task AddCustomerAsync(Customer customer);
  }
}
