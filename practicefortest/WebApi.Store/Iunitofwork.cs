using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
using WebApi.Store.Repositories;

namespace WebApi.Store
{
    public interface Iunitofwork
    {
        IBookRepository _BookRepository { get; }
        IStudentBookRepository _StudentBookRepository { get; }
        IStudentRepository _StudentRepository { get;}
        void Save();

    }
}
