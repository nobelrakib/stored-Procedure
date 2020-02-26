using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Core.Contexts;
using Ecommerce.Core.Entities;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Ecommerce.Core.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(DbContext dbcontext) : base(dbcontext)
        {

        }
        public Product GetProductByName(string name)
        {
           return _dbSet.Where(x => x.Name == name).FirstOrDefault();

        }

    }
}

       



