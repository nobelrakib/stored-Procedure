using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Core.Contexts;
using Ecommerce.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;
namespace Ecommerce.Core.UnitOfWork
{
    public interface IStoreUnitOfWork : IUnitOfWork<StoreContext>
    {
        ICategoryRepository CategoryRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IProductCategoryRepository ProductCategoryRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }

    }
}
