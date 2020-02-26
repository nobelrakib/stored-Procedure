using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce.Core.Repositories
{
    public class OrderRepository : Repository<Order2>,IOrderRepository
    {
        public OrderRepository(DbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
