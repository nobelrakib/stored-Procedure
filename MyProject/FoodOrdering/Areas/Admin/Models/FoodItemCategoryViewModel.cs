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
    public class FoodItemCategoryViewModel
    {
        private IFoodItemCategoryService _fooditemcategoryService;

        public FoodItemCategoryViewModel()
        {
            _fooditemcategoryService = Startup.AutofacContainer.Resolve<IFoodItemCategoryService>();
        }

        public FoodItemCategoryViewModel(IFoodItemCategoryService fooditemcategoryService)
        {
            _fooditemcategoryService = fooditemcategoryService;
        }


        public object GetFooditemCategory(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _fooditemcategoryService.GetFoodItemCategory(
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
                                record.FoodItemId.ToString(),
                                record.CategoryName,
                                record.CategoryId.ToString(),
                                record.Foodname
                        }
                    ).ToArray()

            };
        }
    }
}
