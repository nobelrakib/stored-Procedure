using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;
        public CustomerService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }
        public Customer GetCustomer(int id)
        {
            return _storeUnitOfWork.CustomerRepository.GetById(id);
        }
    }
}
