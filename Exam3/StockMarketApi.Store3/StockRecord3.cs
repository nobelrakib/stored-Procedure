using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
    public class StockRecord3
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public DateTime TradingDay { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public Company3 Company3 { get; set; }
    }
}
