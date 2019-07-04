using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
  public class Customer
  {
    internal Customer()
    {
      CustomerId = Guid.NewGuid();
    }
    public Guid CustomerId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Telephone { get; set; }

    public List<Order> Orders { get; set; }
  }
}
