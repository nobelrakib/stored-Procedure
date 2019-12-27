using System;
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
    }
}
