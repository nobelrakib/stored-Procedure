using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public class OnlinePayment : Payment
    {
        public string CardNumber { get; set; }
    }
}
