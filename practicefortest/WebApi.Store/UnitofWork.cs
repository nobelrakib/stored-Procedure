using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
using WebApi.Store.Repositories;

namespace WebApi.Store
{
    public class UnitofWork : Iunitofwork
    {
        private LibraryContext _context;
        public IBookRepository _BookRepository { get; private set; }
        public IStudentBookRepository _StudentBookRepository { get; private set; }
        public IStudentRepository _StudentRepository { get; private set; }


        public UnitofWork(string connectionstring, string migrationassemblyname)
        {
            _context = new LibraryContext(connectionstring, migrationassemblyname);
            _BookRepository = new BookRepository(_context);
            _StudentBookRepository = new StudentBookRepository(_context);
            _StudentRepository = new StudentRepository(_context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}