using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>

    {
        Product GetProductByName(string name);
    }
}
