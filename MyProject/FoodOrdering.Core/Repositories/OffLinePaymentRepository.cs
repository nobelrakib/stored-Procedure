using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace FoodOrdering.Core.Repositories
{
    public class OffLinePaymentRepository : Repository<OffLinePayment>, IOffLinePaymentRepository
    {
       public OffLinePaymentRepository(DbContext dbContext) : base(dbContext)
       {
        
       }
    }
}
