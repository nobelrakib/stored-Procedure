using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace StockMarketApi.Store3
{
    public class CompanyRepository : ICompanyRepository
    {
        private StockMarketContext3 _context;
        public CompanyRepository(StockMarketContext3 _context)
        {
            this._context = _context;
        }
        public List<Company3> Get()
        {
           return _context.Companies3.ToList();
        }
        public Company3 Get(string symbol)
        {
            return _context.Companies3.Where(x => x.Symbol == symbol).FirstOrDefault();
        }
        public void Create(string symbol,string name)
        {
            _context.Companies3.Add(new Company3
            {
                Name = name,
                Symbol = symbol
            }); 
        }
        public void Delete(Company3 company)
        {
            _context.Companies3.Remove(company);
        }

    }
}
