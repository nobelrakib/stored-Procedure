using System;
using System.Collections.Generic;
using System.Text;
using finalproject2.Core.Contexts;
using finalproject2.Core.Repositories;
using finalproject2.Data;

namespace finalproject2.Core.UnitOfWork
{
    public class PracticeUnitofWork : UnitOfWork<PracticeContext>,IPracticeUnitOfWork
    {
        public IManagerRepository ManagerRepositroy { get; set; }
        public PracticeUnitofWork(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {
            ManagerRepositroy = new ManagerRepository(_dbContext);
           // CategoryRepository = new CategoryRepository(_dbContext);
        }
    }
}
