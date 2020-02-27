using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FoodOrdering.Core.Contexts;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.Repositories;
using FoodOrdering.Core.Services;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public CoreModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FoodStoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<FoodStoreContext>().As<IFoodStoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();
            builder.RegisterType<FoodStoreUnitofWork>().As<IFoodStoreUnitofWork>()
                  .WithParameter("connectionString", _connectionString)
                  .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                  .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<FoodItemRepository>().As<IFoodItemRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<FoodItemService>().As<IFoodItemService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<FoodItemCategoryRepository>().As<IFoodItemCategoryRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<FoodItemCategoryService>().As<IFoodItemCategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<FixedAmountDiscountRepository>().As<IFixedAmountDiscountRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<FixedAmountDiscountService>().As<IFixedAmountDiscountService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PercentageAmountDiscountRepository>().As<IPercentageAmountDiscount>()
              .InstancePerLifetimeScope();
            builder.RegisterType<PercentageAmountDiscountService>().As<IPercentageAmountDiscountService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PendingOrderService>().As<IPendingOrderService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PendingOrderRepository>().As<IPendingOrderRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<ConfirmedOrderService>().As<IConfirmedOrderService>()
               .InstancePerLifetimeScope();
            builder.RegisterType<ConfirmedOrderRepository>().As<IConfirmedOrderRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>()
               .InstancePerLifetimeScope();
            builder.RegisterType<PaymentService>().As<IPaymentService>()
               .InstancePerLifetimeScope();
            builder.RegisterType<OnlinePaymentRepository>().As<IOnlinePaymentRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<OffLinePaymentRepository>().As<IOffLinePaymentRepository>()
               .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
