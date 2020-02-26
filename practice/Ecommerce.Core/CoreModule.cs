using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Autofac;
using Ecommerce.Core.Contexts;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Repositories;
using Ecommerce.Core.Services;
using Ecommerce.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Core
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
            builder.RegisterType<StoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<StoreContext>().As<IStoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<StoreUnitOfWork>().As<IStoreUnitOfWork>()
                 .WithParameter("connectionString", _connectionString)
                 .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                 .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
