using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Core.Entities;
namespace Ecommerce.Core.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        void RemovePc(int id1, int id2);
    }
}
