using finalproject2.Core.Contexts;
using finalproject2.Core.Repositories;
using finalproject2.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalproject2.Core.UnitOfWork
{
    public interface IPracticeUnitOfWork : IUnitOfWork<PracticeContext>
    {
        IManagerRepository ManagerRepositroy { get; set; }
    }
}
