using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public abstract class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
