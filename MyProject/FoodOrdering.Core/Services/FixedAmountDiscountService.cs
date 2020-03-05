using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public class FixedAmountDiscountService : IFixedAmountDiscountService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;

        public FixedAmountDiscountService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewDiscountType(FixedAmountDiscount fixedamountdiscount)
        {
            if (fixedamountdiscount == null )
                throw new InvalidOperationException("amount  is missing");

            _storeUnitOfWork.FixedAmountDiscountRepository.Add(fixedamountdiscount);
            _storeUnitOfWork.Save();
        }

        public IEnumerable<FixedAmountDiscount> GetFixedAmountDiscount(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.FixedAmountDiscountRepository.Get(
                out total,
                out totalFiltered,
                x => x.Amount.ToString().Contains(searchText),
                null,
                "FoodItem",
                pageIndex,
                pageSize,
                true);
        }
        public void DeleteFixedAmountDiscount(int id)
        {
            _storeUnitOfWork.FixedAmountDiscountRepository.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditFixedAmountDiscount(FixedAmountDiscount fixedamountdiscount)
        {
            var oldamount = _storeUnitOfWork.FixedAmountDiscountRepository.GetById(fixedamountdiscount.Id);
            oldamount.Amount = fixedamountdiscount.Amount;
            _storeUnitOfWork.Save();
        }
        public FixedAmountDiscount GetFixedAmountDiscount(int id)
        {
            return _storeUnitOfWork.FixedAmountDiscountRepository.GetById(id);
        }
    }
}
