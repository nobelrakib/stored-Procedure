using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace FoodOrdering.Core.Repositories
{
    public class FoodItemRepository : Repository<FoodItem>, IFoodItemRepository
    {
        public FoodItemRepository(DbContext dbContext)
          : base(dbContext)
        {

        }
        public FoodItem SearchByFooditem(string name)
        {
            return _dbSet.Where(x => x.Name == name).FirstOrDefault();
        }
        public IList<FoodItem> FoodList() => _dbSet.ToList();
    }
}
