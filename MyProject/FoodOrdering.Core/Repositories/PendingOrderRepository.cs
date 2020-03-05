using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Data;
using FoodOrdering.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace FoodOrdering.Core.Repositories
{
    public class PendingOrderRepository : Repository<PendingOrder>, IPendingOrderRepository
    {
        public PendingOrderRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public IList<PendingOrder> ListOfPendingOrder()
        {
            return _dbSet.ToList();
        }
        public IList<PendingOrder> ListOfPendingOrder(string userId)
        {
            return _dbSet.Where(x => x.UserId == userId).ToList();
        }
    }
}
