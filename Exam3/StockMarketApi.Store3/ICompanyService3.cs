using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
   public interface ICompanyService3
    {
        List<Company3> Get();
        Company3 Get(string symbol);
        void Create(string symbol, string name);
        void Update(string symbol, string name);
        void Delete(string symbol);

    }
}
