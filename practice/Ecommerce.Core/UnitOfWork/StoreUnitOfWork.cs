using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Contexts;
using Ecommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
namespace Ecommerce.Core.UnitOfWork
{
    public class StoreUnitOfWork : UnitOfWork<StoreContext>,IStoreUnitOfWork
    {
        public  ICategoryRepository CategoryRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IProductCategoryRepository ProductCategoryRepository { get; set; }
        public StoreUnitOfWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            CategoryRepository = new CategoryRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);
            OrderRepository = new OrderRepository(_dbContext);
            ProductCategoryRepository = new ProductCategoryRepository(_dbContext);
        }
    }
}
