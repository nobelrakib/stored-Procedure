using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace FoodOrdering.Core.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
           : base(dbContext)
        {

        }
        public Category SearchByCategoryName(string name)
        {
            return _dbSet.Where(x => x.Name == name).FirstOrDefault();
        }
        public IList<Category> GetCategoryList()
        {
            return _dbSet.ToList();
        }

    }
}
