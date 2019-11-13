using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
    public interface ICompanyRepository
    {
        List<Company3> Get();
        Company3 Get(string symbol);
        void Create(string symbol, string name);
        void Delete(Company3 company);
    }
}
