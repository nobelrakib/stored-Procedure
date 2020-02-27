using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public abstract class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int FoodItemId { get; set; }
        public Customer Customer { get; set; }
        public FoodItem FoodItem { get; set; }
        public OnlinePayment OnlinePayment { get; set; }
        public OffLinePayment OffLinePayment { get; set; }
    }
}
