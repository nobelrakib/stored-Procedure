using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;

namespace FoodOrdering.Core.Services
{
    public interface IFixedAmountDiscountService
    {
        FixedAmountDiscount GetFixedAmountDiscount(int id);
        void EditFixedAmountDiscount(FixedAmountDiscount fixedamountdiscount);
        void DeleteFixedAmountDiscount(int id);
        IEnumerable<FixedAmountDiscount> GetFixedAmountDiscount(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void AddNewDiscountType(FixedAmountDiscount fixedamountdiscount);
        
    }
}
