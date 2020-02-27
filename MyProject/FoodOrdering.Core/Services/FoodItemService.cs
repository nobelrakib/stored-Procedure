using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Core.Services
{
    public class FoodItemService : IFoodItemService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;

        public FoodItemService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewFoodItem(FoodItem fooditem)
        {
            if (fooditem == null || string.IsNullOrWhiteSpace(fooditem.Name))
                throw new InvalidOperationException("FoodItem name is missing");

            _storeUnitOfWork.FoodItemRepository.Add(fooditem);
            _storeUnitOfWork.Save();
        }

        public IEnumerable<FoodItem> GetCategories(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.FoodItemRepository.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public void DeleteFoodItem(int id)
        {
            _storeUnitOfWork.FoodItemRepository.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditFoodItem(FoodItem FoodItem)
        {
            var oldFoodItem = _storeUnitOfWork.FoodItemRepository.GetById(FoodItem.Id);
            oldFoodItem.Name = FoodItem.Name;
            oldFoodItem.Price = FoodItem.Price;
            _storeUnitOfWork.Save();
        }
        public FoodItem GetFoodItem(int id)
        {
            return _storeUnitOfWork.FoodItemRepository.GetById(id);
        }
        public FoodItem GetFoodItemByName(string name)
        {
            return _storeUnitOfWork.FoodItemRepository.SearchByFooditem(name);
        }
        public IList<FoodItem> GetFoodItemList()
        {
            return _storeUnitOfWork.FoodItemRepository.FoodList();
        }
    }
}
