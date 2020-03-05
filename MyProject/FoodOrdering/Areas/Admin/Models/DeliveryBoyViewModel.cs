using Autofac;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Areas.Admin.Models
{
    public class DeliveryBoyViewModel : BaseModel
    {
        private IDeliveryService _deliveryService;

        public DeliveryBoyViewModel()
        {
            _deliveryService = Startup.AutofacContainer.Resolve<IDeliveryService>();
        }

        public DeliveryBoyViewModel(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        public object GetDeliveries(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _deliveryService.Getdeliveries(
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
                                record.Email,
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }
        public void Delete(int id)
        {
            _deliveryService.DeleteDeliveryBoy(id);
        }
    }
}
