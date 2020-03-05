using Autofac;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Areas.Admin.Models
{
    public class DeliveryBoyUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PendingOrderId { get; set; }

        private IDeliveryService _deliveryService;

        public DeliveryBoyUpdateModel()
        {
            _deliveryService = Startup.AutofacContainer.Resolve<IDeliveryService>();
            //_fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
        }

        public DeliveryBoyUpdateModel(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
            
        }

        public void AddNewDeliveryBoy()
        {
            try
            {
                var db = new DeliveryBoy
                {
                    Name = this.Name,
                    Email = this.Email
                };
                _deliveryService.AddNewDeliveryBoy(db);
                //{
                //    Name = this.Name,
                //    Email=this.Email
                //});
                
                Notification = new NotificationModel("Success!", "Category successfuly created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please try again",
                    NotificationType.Fail);
            }
        }


        public void EditDeliveryBoy()
        {
            try
            {
                _deliveryService.EditDeliveryBoy(new DeliveryBoy
                {
                    Id = this.Id,
                    Name = this.Name,
                    Email=this.Email
                });

                Notification = new NotificationModel("Success!", "Category successfuly updated", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please try again",
                    NotificationType.Fail);
            }
        }

        public void Load(int id)
        {
            var deliveryboy = _deliveryService.GetDeliveryBoy(id);
            if (deliveryboy != null)
            {
                Id = deliveryboy.Id;
                Name = deliveryboy.Name;
                Email = deliveryboy.Email;
            }
        }
    }
}
