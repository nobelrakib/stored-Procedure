using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
    public interface IStockService3
    {
        List<StockRecord3> Get(string symbol);
        List<StockRecord3> Get(string symbol, DateTime first, DateTime last);
        void Create(int id, DateTime date, int minprice, int maxprice);
        void Update(string symbol, int minprice);
        void Delete(string symbol);
        void Delete(string symbol, DateTime date);
    }
}
