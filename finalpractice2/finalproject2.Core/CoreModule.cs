using Autofac;
using finalproject2.Core.Contexts;
using finalproject2.Core.Repositories;
using finalproject2.Core.Services;
using finalproject2.Core.UnitOfWork;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
//using System.Reflection;
using System.Text;

namespace finalproject2.Core
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
            builder.RegisterType<PracticeContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<PracticeContext>().As<IPracticeContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<PracticeUnitofWork>().As<IPracticeUnitOfWork>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<ManagerRepository>().As<IManagerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ManagerService>().As<IManagerService>()
                .InstancePerLifetimeScope();

           // builder.RegisterType<ProductRepository>().As<IProductRepositroy>()
               // .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
