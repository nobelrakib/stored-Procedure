using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;

namespace WebApi.Store
{
    public class unitofwork
    {
        private librarycontext _context;

        public Ibookrespiratory Bookrespiratory { get; private set; }
        public Istudentbookrespiratory Studentbookrespiratory { get; private set; }
        public Istudentrespiratory Studentrespiratory { get; private set; }
        

       public unitofwork(string connectionString, string migrationAssemblyName)
        {
            _context = new librarycontext(connectionString, migrationAssemblyName);

            Bookrespiratory = new bookrespiratory(_context);
            Studentbookrespiratory = new studentbookrespiratory(_context);
            Studentrespiratory = new studentrespiratory(_context);
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
