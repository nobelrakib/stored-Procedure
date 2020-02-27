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
    public class FoodItemViewModel : BaseModel
    {
        private IFoodItemService _fooditemService;

        public FoodItemViewModel()
        {
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
        }

        public FoodItemViewModel(IFoodItemService fooditemService)
        {
            _fooditemService = fooditemService;
        }


        public object GetFooditems(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _fooditemService.GetCategories(
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
                                record.Name,
                                record.Description,
                                record.Price.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }
        public void Delete(int id)
        {
            _fooditemService.DeleteFoodItem(id);
        }

    }
}
