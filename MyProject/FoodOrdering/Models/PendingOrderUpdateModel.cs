using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Core.Services;
using FoodOrdering.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;
namespace FoodOrdering.Models
{ 
     public class PendingOrderUpdateModel : BaseModel
     { 
        public int CustomerId { get; set; }
        public int FoodItemId { get; set; }
        public Customer Customer { get; set; }
        public FoodItem FoodItem { get; set; }
        private IPendingOrderService _pendingorderService;
        private IFoodItemService _fooditemService;
        private ICustomerService _customerService;
        public PendingOrderUpdateModel()
        {
            _pendingorderService = Startup.AutofacContainer.Resolve<IPendingOrderService>();
            _fooditemService= Startup.AutofacContainer.Resolve<IFoodItemService>();
            _customerService= Startup.AutofacContainer.Resolve<ICustomerService>();
        }

        public PendingOrderUpdateModel(IPendingOrderService pendingOrderService,IFoodItemService foodItemService,ICustomerService customerService)
        {
            _pendingorderService= pendingOrderService;
            _fooditemService = foodItemService;
            _customerService = customerService;
        }
        public void AddNewOrder()
        {
            try
            {            
             FoodItem = _fooditemService.GetFoodItem(FoodItemId);
             Customer = _customerService.GetCustomer(CustomerId);
            _pendingorderService.AddNewOrder(new PendingOrder
            {
                FoodItem=FoodItem,
                Customer=Customer

            });

            Notification = new NotificationModel("Success!", "FoodItem successfuly created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create FoodItem, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create FoodItem, please try again",
                    NotificationType.Fail);
            }
        }

    }
}
