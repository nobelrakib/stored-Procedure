using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Ecommerce.Core.Repositories
{
    public class ProductCategoryRepository :  Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DbContext dbcontext) : base(dbcontext)
        {

        }
        public void RemovePc(int id1,int id2)
        {
            ProductCategory pc = _dbSet.Where(x => x.ProductId == id1 && x.CategoryId == id2).FirstOrDefault();
            Remove(pc);
        }
    }
}
