using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Entities
{
    public class PercentageDiscount : Discount
    {
        public override double CalculatePriceAfterDiscount(double price)
        {
            return price * Amount / 100.0;
        }
    }
}
