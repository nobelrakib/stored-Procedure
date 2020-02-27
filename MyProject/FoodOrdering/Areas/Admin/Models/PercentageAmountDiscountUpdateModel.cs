using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Areas.Admin.Models
{
    public class PercentageAmountDiscountUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public double amount { get; set; }
        public IList<FoodItem> FoodList { get; set; }
        public string[] FoodItemIds { get; set; }

        private IPercentageAmountDiscountService _percentageamountdiscountService;
        private IFoodItemService _fooditemService;
        public PercentageAmountDiscountUpdateModel()
        {
            _percentageamountdiscountService = Startup.AutofacContainer.Resolve<IPercentageAmountDiscountService>();
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
        }

        public PercentageAmountDiscountUpdateModel(IPercentageAmountDiscountService percentageamountdiscount, IFoodItemService fooditemService)
        {
            _percentageamountdiscountService = percentageamountdiscount;
            _fooditemService = fooditemService;
        }

        public void AddNewFixedAmount()
        {
            try
            {
                _percentageamountdiscountService.AddNewDiscountType(new PercentageAmountDiscount
                {
                    Amount = amount,
                    FoodItem = _fooditemService.GetFoodItem(Convert.ToInt32(FoodItemIds[0]))

                });

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


        public void EditPercentageAmount()
        {
            try
            {
                _percentageamountdiscountService.EditPercentageAmountDiscount(new PercentageAmountDiscount
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
            var discount = _percentageamountdiscountService.GetPercentageAmountDiscount(id);
            if (discount != null)
            {
                Id = discount.Id;
                amount = discount.Amount;
            }
        }
        public void ListofFood() => FoodList = _fooditemService.GetFoodItemList();
    }
}
