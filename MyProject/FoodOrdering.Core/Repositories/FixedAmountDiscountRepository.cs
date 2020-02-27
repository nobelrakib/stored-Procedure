using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Core.Repositories
{
    public class FixedAmountDiscountRepository : Repository<FixedAmountDiscount>,IFixedAmountDiscountRepository
    {
        public FixedAmountDiscountRepository(DbContext dbContext)
          : base(dbContext)
        {

        }
    }
}
