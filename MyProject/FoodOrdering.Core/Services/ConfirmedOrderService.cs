using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public class ConfirmedOrderService : IConfirmedOrderService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;

        public ConfirmedOrderService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewOrder(ConfirmedOrder confirmedorder)
        {
            if (confirmedorder == null)
                throw new InvalidOperationException("Order is missing");

            _storeUnitOfWork.ConfirmedOrderRepository.Add(confirmedorder);
            _storeUnitOfWork.Save();
        }

        public IEnumerable<ConfirmedOrder> GetConfirmedOrders(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.ConfirmedOrderRepository.Get(
                out total,
                out totalFiltered,
                x => x.Date.ToString().Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public void DeleteConfirmedOrder(int id)
        {
            _storeUnitOfWork.ConfirmedOrderRepository.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditConfirmedOrder(ConfirmedOrder confirmedorder)
        {
            var oldorder = _storeUnitOfWork.ConfirmedOrderRepository.GetById(confirmedorder.Id);
            oldorder.Date = DateTime.Now;
            _storeUnitOfWork.Save();
        }
        public ConfirmedOrder GetConfirmedOrder(int id)
        {
            return _storeUnitOfWork.ConfirmedOrderRepository.GetById(id);
        }
    }
}
