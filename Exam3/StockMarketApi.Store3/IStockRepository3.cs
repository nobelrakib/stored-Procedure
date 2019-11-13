using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
    public interface IStockRepository3
    {
        List<StockRecord3> Get(string symbol);
        List<StockRecord3> Get();
        void Create(int companyid, DateTime date, int minprice, int maxprice);
        void Delete(StockRecord3 record);
        
    }
}
