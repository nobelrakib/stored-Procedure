using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Core.Services
{
    public interface IPaymentService
    {
        void AddOfflinePayment(OffLinePayment offlinepayment);
        void AddOnlinePayment(OnlinePayment onlinepayment);
        IEnumerable<OnlinePayment> GetOnlinePayments(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        IEnumerable<OffLinePayment> GetOfflinePayments(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void DeleteOfflinePayment(int id);
        void DeleteOnlinePayment(int id);
        void EditOnlinePayment(OnlinePayment onlinepayment);
        void EditOfflinePayment(OffLinePayment offlinepayment);
        OnlinePayment GetOnlinePayment(int id);
        OffLinePayment GetOfflinePayment(int id);
    }
}
