using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Data;
using FoodOrdering.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace FoodOrdering.Core.Repositories
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
