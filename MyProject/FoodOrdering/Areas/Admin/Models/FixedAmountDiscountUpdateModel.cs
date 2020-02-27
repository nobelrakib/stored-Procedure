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
    public class FixedAmountDiscountUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public double amount { get; set; }
        public IList<FoodItem> FoodList { get; set; }
        public string[] FoodItemIds { get; set; }

        private IFixedAmountDiscountService _fixedamountdiscountService;
        private IFoodItemService _fooditemService;
        public FixedAmountDiscountUpdateModel()
        {
            _fixedamountdiscountService = Startup.AutofacContainer.Resolve<IFixedAmountDiscountService>();
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
        }

        public FixedAmountDiscountUpdateModel(IFixedAmountDiscountService fixedamountdiscount, IFoodItemService fooditemService)
        {
            _fixedamountdiscountService = fixedamountdiscount;
            _fooditemService = fooditemService;
        }

        public void AddNewFixedAmount()
        {
            try
            {
                _fixedamountdiscountService.AddNewDiscountType(new FixedAmountDiscount
                {
                    Amount = amount,
                    FoodItem = _fooditemService.GetFoodItem(Convert.ToInt32(FoodItemIds[0]))

                }) ;

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


        public void EditFixedAmount()
        {
            try
            {
                _fixedamountdiscountService.EditFixedAmountDiscount(new FixedAmountDiscount
                {
                    Id = this.Id,
                    Amount = this.amount
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
            var discount = _fixedamountdiscountService.GetFixedAmountDiscount(id);
            if (discount != null)
            {
                Id = discount.Id;
                amount = discount.Amount;
            }
        }
        public void ListofFood() => FoodList = _fooditemService.GetFoodItemList();

    }
}
