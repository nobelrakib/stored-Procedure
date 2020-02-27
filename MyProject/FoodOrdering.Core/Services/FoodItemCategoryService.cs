using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public class FoodItemCategoryService : IFoodItemCategoryService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;

        public FoodItemCategoryService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewFoodItemCategory(FoodItemCategory fooditemcategory)
        {
            if (fooditemcategory == null || string.IsNullOrWhiteSpace(fooditemcategory.CategoryName)|| string.IsNullOrWhiteSpace(fooditemcategory.Foodname))
                throw new InvalidOperationException("FoodItem name is missing");

            _storeUnitOfWork.FoodItemCategoryRepository.Add(fooditemcategory);
            _storeUnitOfWork.Save();
        }

        public IEnumerable<FoodItemCategory> GetFoodItemCategory(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.FoodItemCategoryRepository.Get(
                out total,
                out totalFiltered,
                x => x.Foodname
                .Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
    }
}
