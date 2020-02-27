using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;
namespace FoodOrdering.Core.Repositories
{
    public class PercentageAmountDiscountRepository : Repository<PercentageAmountDiscount>,IPercentageAmountDiscount
    {
        public PercentageAmountDiscountRepository(DbContext dbContext)
          : base(dbContext)
        {

        }
    }
}
