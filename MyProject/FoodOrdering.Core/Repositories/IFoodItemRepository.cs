using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Core.Repositories
{
    public interface IFoodItemRepository : IRepository<FoodItem>
    {
        FoodItem SearchByFooditem(string name);
        IList<FoodItem> FoodList();
    }
}
