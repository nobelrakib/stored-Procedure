using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public class FoodImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string AlternativeText { get; set; }
        public FoodItem FoodItem { get; set; }
        public int FoodItemId { get; set; }
    }
}
