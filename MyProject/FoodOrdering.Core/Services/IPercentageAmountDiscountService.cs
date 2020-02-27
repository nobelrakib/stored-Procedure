using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public interface IPercentageAmountDiscountService
    {
        void AddNewDiscountType(PercentageAmountDiscount percentageamountdiscount);
        IEnumerable<PercentageAmountDiscount> GetPercentageAmountDiscount(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void DeletePercentageAmountDiscount(int id);
        void EditPercentageAmountDiscount(PercentageAmountDiscount percentageamountdiscount);
        PercentageAmountDiscount GetPercentageAmountDiscount(int id);
    }
}
