using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
    public class UnitOfWork3
    {
        private StockMarketContext3 _context;

        public ICompanyRepository _companyRepository { get; private set; }
        public IStockRepository3 _stockrepository { get; private set; }
        public UnitOfWork3(string connectionString, string migrationAssemblyName)
        {
            _context = new StockMarketContext3(connectionString, migrationAssemblyName);

            _companyRepository = new CompanyRepository(_context);

            _stockrepository = new StockRepository3(_context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
