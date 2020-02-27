using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public interface IFoodItemCategoryService
    {
        void AddNewFoodItemCategory(FoodItemCategory fooditemcategory);
        IEnumerable<FoodItemCategory> GetFoodItemCategory(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);

    }
}
