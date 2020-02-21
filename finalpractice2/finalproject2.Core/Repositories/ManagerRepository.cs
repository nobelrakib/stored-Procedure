using finalproject2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using finalproject2.Data;
namespace finalproject2.Core.Repositories
{
    public class ManagerRepository : Repository<Manager>,IManagerRepository
    {
        public ManagerRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
