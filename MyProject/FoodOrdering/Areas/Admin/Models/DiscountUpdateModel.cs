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
    public class DiscountUpdateModel : BaseModel
    {
        public static int Id { get; set; }
        public double amount { get; set; }
        public IList<FoodItem> FoodList { get; set; }
        public string[] FoodItemIds { get; set; }
        public string DiscountName { get; set; }
        public IList<string> DiscountListName { get; set; }

        private IFixedAmountDiscountService _fixedamountdiscountService;
        private IFoodItemService _fooditemService;
        private IPercentageAmountDiscountService _percentageAmountDiscountService;
        public DiscountUpdateModel()
        {
            _fixedamountdiscountService = Startup.AutofacContainer.Resolve<IFixedAmountDiscountService>();
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
            _percentageAmountDiscountService= Startup.AutofacContainer.Resolve<IPercentageAmountDiscountService>();
        }

        public DiscountUpdateModel(IFixedAmountDiscountService fixedamountdiscount,
            IFoodItemService fooditemService,
            IPercentageAmountDiscountService percentageAmountDiscountService)
            
        {
            _fixedamountdiscountService = fixedamountdiscount;
            _fooditemService = fooditemService;
            _percentageAmountDiscountService = percentageAmountDiscountService;
        }
        public void InitializeDiscountListName()
        {
            DiscountListName = new List<string>();
            DiscountListName.Add("fixed amount discount");
            DiscountListName.Add("Percentage amount discount");
        }

        public void AddDiscount(int id)
        {
            try
            {
                if (DiscountName == "fixed amount discount")
                {
                    _fixedamountdiscountService.AddNewDiscountType(new FixedAmountDiscount
                    {
                        Amount = amount,
                        FoodItem = _fooditemService.GetFoodItem(id)

                    });
                }
                else
                {
                    _percentageAmountDiscountService.AddNewDiscountType(new PercentageAmountDiscount
                    {
                        Amount = amount,
                        FoodItem = _fooditemService.GetFoodItem(id)

                    });
                }
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

        public void InitializeId(int id) => Id = id;
        public int GetId()
        {
            return Id;
        }

        //public void EditFixedAmount()
        //{
        //    try
        //    {
        //        _fixedamountdiscountService.EditFixedAmountDiscount(new FixedAmountDiscount
        //        {
        //            Id = this.Id,
        //            Amount = this.amount
        //        });

        //        Notification = new NotificationModel("Success!", "Category successfuly updated", NotificationType.Success);
        //    }
        //    catch (InvalidOperationException iex)
        //    {
        //        Notification = new NotificationModel(
        //            "Failed!",
        //            "Failed to update category, please provide valid name",
        //            NotificationType.Fail);
        //    }
        //    catch (Exception ex)
        //    {
        //        Notification = new NotificationModel(
        //            "Failed!",
        //            "Failed to update category, please try again",
        //            NotificationType.Fail);
        //    }
        //}

        //public void Load(int id)
        //{
        //    var discount = _fixedamountdiscountService.GetFixedAmountDiscount(id);
        //    if (discount != null)
        //    {
        //        Id = discount.Id;
        //        amount = discount.Amount;
        //    }
        //}
        //public void ListofFood() => FoodList = _fooditemService.GetFoodItemList();

    }
}
