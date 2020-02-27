using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public class PercentageAmountDiscountService : IPercentageAmountDiscountService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;

        public PercentageAmountDiscountService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewDiscountType(PercentageAmountDiscount percentageamountdiscount)
        {
            if (percentageamountdiscount == null)
                throw new InvalidOperationException("amount  is missing");

            _storeUnitOfWork.PercentageAmountDiscountRepository.Add(percentageamountdiscount);
            _storeUnitOfWork.Save();
        }

        public IEnumerable<PercentageAmountDiscount> GetPercentageAmountDiscount(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.PercentageAmountDiscountRepository.Get(
                out total,
                out totalFiltered,
                x => x.Amount.ToString().Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public void DeletePercentageAmountDiscount(int id)
        {
            _storeUnitOfWork.PercentageAmountDiscountRepository.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditPercentageAmountDiscount(PercentageAmountDiscount percentageamountdiscount)
        {
            var oldamount = _storeUnitOfWork.PercentageAmountDiscountRepository.GetById(percentageamountdiscount.Id);
            oldamount.Amount = percentageamountdiscount.Amount;
            _storeUnitOfWork.Save();
        }
        public PercentageAmountDiscount GetPercentageAmountDiscount(int id)
        {
            return _storeUnitOfWork.PercentageAmountDiscountRepository.GetById(id);
        }

    }
}
