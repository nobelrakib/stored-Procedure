using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketApi.Store3
{
    public class CompanyService3 : ICompanyService3
    {
        private UnitOfWork3 _unitofwork;
        public CompanyService3(UnitOfWork3 _unitofwork)
        {
            this._unitofwork = _unitofwork;
        }
        public List<Company3> Get()
        {
            return _unitofwork._companyRepository.Get();
        }
        public Company3 Get(string symbol)
        {
            return _unitofwork._companyRepository.Get(symbol);
        }
        public void Create(string symbol,string name)
        {
            _unitofwork._companyRepository.Create(symbol, name);
            _unitofwork.Save();
        }
        public void Update(string symbol,string name)
        {
            var company = _unitofwork._companyRepository.Get(symbol);
            company.Name = name;
            _unitofwork.Save();
        }
        public void Delete(string symbol)
        {
            var company = _unitofwork._companyRepository.Get(symbol);
            _unitofwork._companyRepository.Delete(company);
            _unitofwork.Save();
        }

    }
}
