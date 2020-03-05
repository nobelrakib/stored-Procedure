using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Repositories
{
    public class DeliveryBoyRepository : Repository<DeliveryBoy>,IDeliveryBoyRepository
    {
        public DeliveryBoyRepository(DbContext dbContext)
           : base(dbContext)
        {

        }
    }
}
