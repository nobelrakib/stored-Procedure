using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;


namespace FoodOrdering.Areas.Admin.Models
{
    public class FoodItemUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public string Description { get; set; }
        public IList<FoodItem> FoodList { get; set; }
        private IFoodItemService _fooditemService;

        public FoodItemUpdateModel()
        {
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
            
        }

        public FoodItemUpdateModel(IFoodItemService fooditemService)
        {
            _fooditemService = fooditemService;
        }

        public void AddNewFoodItem()
        {
            try
            {
                _fooditemService.AddNewFoodItem(new FoodItem
                {
                    Name = this.Name,
                    Price=this.price,
                    Description=this.Description

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


        public void EditFoodItem()
        {
            try
            { 
                 _fooditemService.EditFoodItem(new FoodItem
                {
                    Id = this.Id,
                     Name = this.Name,
                     Price = this.price,
                     Description = this.Description

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
            var fooditem = _fooditemService.GetFoodItem(id);
            if (fooditem != null)
            {
                Id = fooditem.Id;
                Name = fooditem.Name;
                price = fooditem.Price;
                Description = fooditem.Description;
            }
        }
        public void ListofFood() => FoodList = _fooditemService.GetFoodItemList();
    }
}
