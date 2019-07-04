using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
  public class Order
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public DateTime DateCreated { get; set; }
    public string OrderState { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
  }
}
