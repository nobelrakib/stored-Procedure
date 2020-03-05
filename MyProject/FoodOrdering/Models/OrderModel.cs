using Autofac;
using FoodOrdering.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        private IFoodItemService _fooditemService;
        private IPendingOrderService _pendingOrderService;
        public OrderModel()
        {
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
            _pendingOrderService = Startup.AutofacContainer.Resolve<IPendingOrderService>();
        }

        public OrderModel(IFoodItemService fooditemService,IPendingOrderService pendingOrderService)
        {
            _fooditemService = fooditemService;
            _pendingOrderService = pendingOrderService;
        }
        public IEnumerable<OrderModel> ListofOrder(string userId)
        {
            var listoforder = _pendingOrderService.GetUserPendingOrderList(userId);
            var ordermodellist = new List<OrderModel>();
            foreach (var item in listoforder)
            {
                 var fooditem = _fooditemService.GetFoodItem(item.FoodItemId);
                 var singleordermodel = new OrderModel();
                 singleordermodel.FoodName = fooditem.Name;
                 singleordermodel.Price = fooditem.Price;
                 singleordermodel.Description = item.FoodItem.Description;
                 singleordermodel.Id = item.Id;
                 ordermodellist.Add( singleordermodel);
            }
            return ordermodellist;
        }
    }
}
