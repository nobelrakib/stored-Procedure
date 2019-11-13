using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
    public class StockServic3 : IStockService3
    {
        private UnitOfWork3 _unitofwork;
        public StockServic3(UnitOfWork3 _unitofwork)
        {
            this._unitofwork = _unitofwork;
        }
        public List<StockRecord3> Get(string symbol)
        {
            return _unitofwork._stockrepository.Get(symbol);
        }
        public List<StockRecord3> Get()
        {
            return _unitofwork._stockrepository.Get();
        }
        public List<StockRecord3> Get(string symbol,DateTime first,DateTime last)
        {   
            var recordlist=_unitofwork._stockrepository.Get(symbol);
            var list = new List<StockRecord3>();
            foreach(StockRecord3 sp in recordlist)
            {
                if(sp.TradingDay>=first && sp.TradingDay<=last)
                {
                    list.Add(sp);
                }
            }
            return list;
        }
        public void Create(int id,DateTime date,int minprice, int maxprice)
        {
            _unitofwork._stockrepository.Create(id, date, minprice, maxprice);
            _unitofwork.Save();
        }
        public void Update(string symbol,int minprice)
        {
            var recordlist = _unitofwork._stockrepository.Get(symbol);
            foreach (StockRecord3 sp in recordlist)
            {
                if (sp.MinPrice==minprice)
                {
                    sp.MinPrice = 111;
                }
            }
            _unitofwork.Save();
        }
        public void Delete(string symbol)
        {
            var recordlist = _unitofwork._stockrepository.Get(symbol);
            foreach (StockRecord3 sp in recordlist)
            {
                _unitofwork._stockrepository.Delete(sp);
            }
            _unitofwork.Save();
        }
        public void Delete(string symbol,DateTime date)
        {
            var recordlist = _unitofwork._stockrepository.Get(symbol);
            foreach (StockRecord3 sp in recordlist)
            {    
                if(sp.TradingDay==date)
                _unitofwork._stockrepository.Delete(sp);
            }
            _unitofwork.Save();
        }

    }
}
