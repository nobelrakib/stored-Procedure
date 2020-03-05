using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Core.Services
{
    public interface IFoodItemService
    {
        IEnumerable<FoodItem> GetCategories(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered);
        IEnumerable<FoodItem> GetProductByCategoryId(
          int categoryid,
          int pageIndex,
          int pageSize,
          string searchText,
          out int total,
          out int totalFiltered);
        
        void AddNewFoodItem(FoodItem fooditem);
        void DeleteFoodItem(int id);
        void EditFoodItem(FoodItem fooditem);
        FoodItem GetFoodItem(int id);
        FoodItem GetFoodItemByName(string name);
        IList<FoodItem> GetFoodItemList();
    }
}
