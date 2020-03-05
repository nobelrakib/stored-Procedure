using FoodOrdering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Services
{
    public interface IDeliveryService
    {
        void AddNewDeliveryBoy(DeliveryBoy deliveryboy);
        IEnumerable<DeliveryBoy> Getdeliveries(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void DeleteDeliveryBoy(int id);
        void EditDeliveryBoy(DeliveryBoy deliveryboy);
        DeliveryBoy GetDeliveryBoy(int id);
    }
}
