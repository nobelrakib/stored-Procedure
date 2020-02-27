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
    public class PendingOrderViewModel
    {
        public int Id { get; set; }
        private IPendingOrderService _pendingorderService;
        public PendingOrderViewModel()
        {
            _pendingorderService = Startup.AutofacContainer.Resolve<IPendingOrderService>();
        }

        public PendingOrderViewModel(IPendingOrderService pendingorderService)
        {
            _pendingorderService= pendingorderService;
        }

        public object GetOrders(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _pendingorderService.GetPendingOrders(
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
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }
    }
}
