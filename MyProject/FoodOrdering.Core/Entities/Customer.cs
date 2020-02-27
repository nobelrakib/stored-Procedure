using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Password  {get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Order> Orders { get; set; }
       // public IList<ConfirmedOrder> ConfirmedOrders { get; set; }
    }
}
