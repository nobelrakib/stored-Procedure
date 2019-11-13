using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
    public class Company3
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Symbol { get; set; }
        public List<StockRecord3> StockRecords { get; set; }
    }
}
