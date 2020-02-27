using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IList<FoodImage> Images { get; set; }
        public IList<FoodItemCategory> Categories { get; set; }
        public Discount PriceDiscount { get; set; }
        public IList<Order> Orders { get; set; }
       // public ConfirmedOrder ConfirmedOrder { get; set; }
    }
}
