using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Core.Entities;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Ecommerce.Core.Repositories
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(DbContext dbcontext) : base (dbcontext)
        {

        }
        public Category GetCategoryByName(string name)
        {
            return _dbSet.Where(x => x.Name == name).FirstOrDefault();

        }
        public List<Category> GetCategoryList()
        {
           return _dbSet.ToList();
        }
    }
}
