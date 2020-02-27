using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Data;
using FoodOrdering.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace FoodOrdering.Core.Repositories
{
    public class ConfirmedOrderRepository : Repository<ConfirmedOrder>,IConfirmedOrderRepository
    {
        public ConfirmedOrderRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
