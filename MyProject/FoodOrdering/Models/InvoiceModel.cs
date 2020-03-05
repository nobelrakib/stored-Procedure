using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FoodOrdering.Core.Services;
using FoodOrdering.Core.Contexts;
using FoodOrdering.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace FoodOrdering.Models
{
    public class InvoiceModel
    {
        public string Email { get; set; }
        public string UserId { get; set; }
        public int TotalItems { get; set; }
        public Double TotalAmount { get; set; }

        private IFoodItemService _fooditemService;
        private IFixedAmountDiscountService _fixedamountDiscount;
        private IPercentageAmountDiscountService _percentageamountDiscount;
        private IPendingOrderService _pendingorderService;
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        public InvoiceModel()
        {
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
            _fixedamountDiscount = Startup.AutofacContainer.Resolve<IFixedAmountDiscountService>();
            _percentageamountDiscount = Startup.AutofacContainer.Resolve<IPercentageAmountDiscountService>();
            _pendingorderService= Startup.AutofacContainer.Resolve<IPendingOrderService>();
            _userManager= Startup.AutofacContainer.Resolve<UserManager<ExtendedIdentityUser>>();
        }
        public InvoiceModel(IFoodItemService fooditemService,
            IFixedAmountDiscountService fixedamountDiscount,
            IPercentageAmountDiscountService percentageamountDiscount,
            IPendingOrderService pendingorderService)
        {
            _fooditemService = fooditemService;
            _fixedamountDiscount = fixedamountDiscount;
            _percentageamountDiscount = percentageamountDiscount;
            _pendingorderService = pendingorderService;
        }
        public void CreateInvoice(string userId)
        {
            var pendingorderlist = _pendingorderService.GetUserPendingOrderList(userId);
            double amount = 0;
            
            foreach(var item in pendingorderlist)
            {

                var fooditem = _fooditemService.GetFoodItem(item.FoodItemId);
                amount = amount + fooditem.Price;
            }
            TotalAmount = amount;
            TotalItems = pendingorderlist.Count();
            UserId = userId;
            //var s=_userManager.FindByIdAsync()
        }
        public void UserEmail(string email) => Email = email;
    }
}
