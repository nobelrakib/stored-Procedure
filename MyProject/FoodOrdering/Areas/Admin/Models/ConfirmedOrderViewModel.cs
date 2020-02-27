using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;
namespace FoodOrdering.Areas.Admin.Models
{
    
    public class ConfirmedOrderViewModel
    {
        private IConfirmedOrderService _confirmorderService;

        public ConfirmedOrderViewModel()
        {
            _confirmorderService = Startup.AutofacContainer.Resolve<IConfirmedOrderService>();
        }

        public ConfirmedOrderViewModel(IConfirmedOrderService confirmedorderService)
        {
            _confirmorderService = confirmedorderService;
        }

        public object GetOrders(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _confirmorderService.GetConfirmedOrders(
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
                                record.Date.ToString(),
                                record.CustomerId.ToString(),
                                record.FoodItemId.ToString(),
                                //record.Id.ToString()
                        }
                    ).ToArray()

            };
        }
    }
}
