using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Core.Services
{
    public interface IPendingOrderService
    {
        void AddNewOrder(PendingOrder pendingdorder);
        IList<PendingOrder> GetPendingOrderList();
        IEnumerable<PendingOrder> GetPendingOrders(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void DeletePendingOrder(int id);
        void EditPendingOrder(PendingOrder pendingorder);
        PendingOrder GetPendingOrder(int id);
        IList<PendingOrder> GetUserPendingOrderList(string userId);
    }
}
