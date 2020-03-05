﻿using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Contexts;
using FoodOrdering.Core.Repositories;
using FoodOrdering.Data;

namespace FoodOrdering.Core.UnitofWork
{
    public interface IFoodStoreUnitofWork : IUnitOfWork<FoodStoreContext>
    {
       ICategoryRepository CategoryRepository { get; set; }
       IFoodItemRepository FoodItemRepository { get; set; }
       IImageRepository ImageRepository { get; set; }
       IDeliveryBoyRepository DeliveryBoyRepository { get; set; }
       IFixedAmountDiscountRepository FixedAmountDiscountRepository { get; set; }
       IPercentageAmountDiscount PercentageAmountDiscountRepository { get; set; }
       IConfirmedOrderRepository ConfirmedOrderRepository { get; set; }
       IPendingOrderRepository PendingOrderRepository { get; set; }
       IOffLinePaymentRepository OfflinePaymentRepository { get; set; }
       IOnlinePaymentRepository OnlinePaymentReposittory { get; set; }
    }
}
