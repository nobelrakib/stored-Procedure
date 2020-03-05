using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public class PendingOrder : Order
    {
       //public int Id { get; set; }
       //public  DateTime Date { get; set; }
       //public Customer Customer { get; set; }
       //public int CustomerId { get; set; }
       public string UserId { get; set; }
     //  public DeliveryBoy DeliveryBoy { get; set; }
       public ExtendedIdentityUser User { get; set; }
    }
}
