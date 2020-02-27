using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public class PendingOrderService : IPendingOrderService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;

        public PendingOrderService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewOrder(PendingOrder pendingorder)
        {
            if (pendingorder == null)
                throw new InvalidOperationException("Order is missing");

            _storeUnitOfWork.PendingOrderRepository.Add(pendingorder);
            _storeUnitOfWork.Save();
        }

        public IEnumerable<PendingOrder> GetPendingOrders(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.PendingOrderRepository.Get(
                out total,
                out totalFiltered,
                x => x.Date.ToString().Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public void DeletePendingOrder(int id)
        {
            _storeUnitOfWork.PendingOrderRepository.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditPendingOrder(PendingOrder pendingorder)
        {
            var oldorder = _storeUnitOfWork.PendingOrderRepository.GetById(pendingorder.Id);
            oldorder.Date = DateTime.Now;
            _storeUnitOfWork.Save();
        }
        public PendingOrder GetPendingOrder(int id)
        {
            return _storeUnitOfWork.PendingOrderRepository.GetById(id);
        }
    }
}
