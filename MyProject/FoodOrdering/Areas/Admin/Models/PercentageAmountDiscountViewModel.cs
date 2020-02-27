using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Areas.Admin.Models
{
    public class PercentageAmountDiscountViewModel
    {
        private IPercentageAmountDiscountService _percentageamountdiscountService;
        private IFoodItemService _fooditemService;
        public PercentageAmountDiscountViewModel()
        {
            _percentageamountdiscountService = Startup.AutofacContainer.Resolve<IPercentageAmountDiscountService>();
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
        }

        public PercentageAmountDiscountViewModel(IPercentageAmountDiscountService percentageamountdiscount, IFoodItemService fooditemService)
        {
            _percentageamountdiscountService = percentageamountdiscount;
            _fooditemService = fooditemService;
        }

        public object GetFixedAmount(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _percentageamountdiscountService.GetPercentageAmountDiscount(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Amount.ToString()

                        }
                    ).ToArray()

            };
        }
        public void Delete(int id)
        {
            _percentageamountdiscountService.DeletePercentageAmountDiscount(id);
        }
    }
}
