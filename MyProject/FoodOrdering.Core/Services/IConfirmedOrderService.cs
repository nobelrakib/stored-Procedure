using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public interface IConfirmedOrderService
    {
        void AddNewOrder(ConfirmedOrder confirmedorder);
        IEnumerable<ConfirmedOrder> GetConfirmedOrders(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void DeleteConfirmedOrder(int id);
        void EditConfirmedOrder(ConfirmedOrder confirmedorder);
        ConfirmedOrder GetConfirmedOrder(int id);
    }
}
