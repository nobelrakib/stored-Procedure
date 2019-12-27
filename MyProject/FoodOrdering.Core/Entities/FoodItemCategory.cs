using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public class FoodItemCategory
    {
        public int FoodItemId { get; set; }
        public FoodItem FoodItem{ get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
