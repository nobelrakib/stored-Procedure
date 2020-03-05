using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;

namespace FoodOrdering.Areas.Admin.Models
{
    public class FixedAmountDiscountViewModel : BaseModel
    {
        //public int Id { get; set; }
        private IFixedAmountDiscountService _fixedamountdiscountService;

        public FixedAmountDiscountViewModel()
        {
            _fixedamountdiscountService = Startup.AutofacContainer.Resolve<IFixedAmountDiscountService>();
        }

        public FixedAmountDiscountViewModel(IFixedAmountDiscountService fixedamountService)
        {
            _fixedamountdiscountService= fixedamountService;
        }

        public object GetFixedAmount(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _fixedamountdiscountService.GetFixedAmountDiscount(
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
                                record.Amount.ToString(),
                                record.FoodItem.Name,
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }
        public void Delete(int id)
        {
           _fixedamountdiscountService.DeleteFixedAmountDiscount(id);
        }
    }
}
