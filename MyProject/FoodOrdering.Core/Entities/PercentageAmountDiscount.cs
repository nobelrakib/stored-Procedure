using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public class PercentageAmountDiscount : Discount
    {
        public override double CalculatePriceAfterDiscount(double price)
        {
            return price * Amount / 100.0;
        }
    }
}
