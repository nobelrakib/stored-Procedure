using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Services
{
    public class DeliveryService : IDeliveryService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;
        public DeliveryService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewDeliveryBoy(DeliveryBoy deliveryboy)
        {
            if (deliveryboy == null || string.IsNullOrWhiteSpace(deliveryboy.Name))
                throw new InvalidOperationException("deliveryboy name is missing");

            _storeUnitOfWork.DeliveryBoyRepository.Add(deliveryboy);
            _storeUnitOfWork.Save();
        }

        public IEnumerable<DeliveryBoy> Getdeliveries(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.DeliveryBoyRepository.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public void DeleteDeliveryBoy(int id)
        {
            _storeUnitOfWork.DeliveryBoyRepository.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditDeliveryBoy(DeliveryBoy deliveryboy)
        {
            var olddeliveryboy = _storeUnitOfWork.DeliveryBoyRepository.GetById(deliveryboy.Id);
            olddeliveryboy.Name = deliveryboy.Name;
            _storeUnitOfWork.Save();
        }
        public DeliveryBoy GetDeliveryBoy(int id)
        {
            return _storeUnitOfWork.DeliveryBoyRepository.GetById(id);
        }
        
    }
}
