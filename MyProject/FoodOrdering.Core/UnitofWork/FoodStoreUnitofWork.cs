using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Contexts;
using FoodOrdering.Core.Repositories;
using FoodOrdering.Data;
namespace FoodOrdering.Core.UnitofWork
{
    public class FoodStoreUnitofWork : UnitOfWork<FoodStoreContext>, IFoodStoreUnitofWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public IFoodItemRepository FoodItemRepository { get; set; }
        public IDeliveryBoyRepository DeliveryBoyRepository { get; set; }
        public IFixedAmountDiscountRepository FixedAmountDiscountRepository { get; set; }
        public IPercentageAmountDiscount PercentageAmountDiscountRepository { get; set; }
        public IConfirmedOrderRepository ConfirmedOrderRepository { get; set; }
        public IPendingOrderRepository PendingOrderRepository { get; set; }
        
        public IOffLinePaymentRepository OfflinePaymentRepository { get; set; }
        public IOnlinePaymentRepository OnlinePaymentReposittory { get; set; }
        public IImageRepository ImageRepository { get; set; }
        public FoodStoreUnitofWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            FoodItemRepository = new FoodItemRepository(_dbContext);
            CategoryRepository = new CategoryRepository(_dbContext);
            FixedAmountDiscountRepository = new FixedAmountDiscountRepository(_dbContext);
            PercentageAmountDiscountRepository = new PercentageAmountDiscountRepository(_dbContext);
            ConfirmedOrderRepository = new ConfirmedOrderRepository(_dbContext);
            PendingOrderRepository = new PendingOrderRepository(_dbContext);
            OfflinePaymentRepository = new OffLinePaymentRepository(_dbContext);
            OnlinePaymentReposittory = new OnlinePaymentRepository(_dbContext);
            DeliveryBoyRepository = new DeliveryBoyRepository(_dbContext);
            ImageRepository = new ImageRepository(_dbContext);
        }
    }
}
