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
        public FoodStoreUnitofWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            
            CategoryRepository = new CategoryRepository(_dbContext);
        }
    }
}
