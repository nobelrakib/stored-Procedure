using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace StockMarketApi.Store3
{
    public class StockRepository3 : IStockRepository3
    {
        private StockMarketContext3 _context;
        public StockRepository3(StockMarketContext3 _context)
        {
            this._context = _context;
        }
        public List<StockRecord3> Get()
        {
           return _context.StockRecords3.ToList();
        }
        public List<StockRecord3> Get(string symbol)
        {
            var company = _context.Companies3.Where(x => x.Symbol == symbol).FirstOrDefault();
            return _context.StockRecords3.Where(x => x.CompanyId == company.Id).ToList();
        }
        public void Create(int companyid,DateTime date,int minprice,int maxprice)
        {
            _context.StockRecords3.Add(new StockRecord3
            {
               CompanyId=companyid,
               TradingDay=date,
               MinPrice=minprice,
               MaxPrice=maxprice
            }); 
        }
        public void Delete(StockRecord3 record)
        {
            _context.StockRecords3.Remove(record);
        }
    }
}
