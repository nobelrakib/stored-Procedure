using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.DesignPatterns
{
    public class Singleton
    {
        public static List<ConfirmedOrder> OrderList;
        public static List<ConfirmedOrder> ListofOrder()
        {
            if (OrderList == null)
                return OrderList=new List<ConfirmedOrder>();
            else return OrderList;
        }
        public void AddOrder(ConfirmedOrder confirmedorder)
        {
            OrderList.Add(confirmedorder);
        }
    }
}
