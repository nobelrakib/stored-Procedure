using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.UnitofWork;
namespace FoodOrdering.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private IFoodStoreUnitofWork _storeUnitOfWork;
        public PaymentService(IFoodStoreUnitofWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }
        public void AddOfflinePayment(OffLinePayment offlinepayment)
        {
            if (offlinepayment == null )
                throw new InvalidOperationException("Payment is missing");

            _storeUnitOfWork.OfflinePaymentRepository.Add(offlinepayment);
            _storeUnitOfWork.Save();
        }
        public void AddOnlinePayment(OnlinePayment onlinepayment)
        {
            if (onlinepayment == null || string.IsNullOrWhiteSpace(onlinepayment.CardNumber))
                throw new InvalidOperationException("Card Number is missing");

            _storeUnitOfWork.OnlinePaymentReposittory.Add(onlinepayment);
            _storeUnitOfWork.Save();
        }
        public IEnumerable<OnlinePayment> GetOnlinePayments(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.OnlinePaymentReposittory.Get(
                out total,
                out totalFiltered,
                x => x.CardNumber.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public IEnumerable<OffLinePayment> GetOfflinePayments(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.OfflinePaymentRepository.Get(
                out total,
                out totalFiltered,
                x => x.Id.ToString().Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public void DeleteOfflinePayment(int id)
        {
            _storeUnitOfWork.OfflinePaymentRepository.Remove(id);
            _storeUnitOfWork.Save();
        }
        public void DeleteOnlinePayment(int id)
        {
            _storeUnitOfWork.OnlinePaymentReposittory.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditOnlinePayment(OnlinePayment onlinepayment)
        {
            var oldpayment = _storeUnitOfWork.OnlinePaymentReposittory.GetById(onlinepayment.Id);
            oldpayment.OrderId = onlinepayment.OrderId;
            _storeUnitOfWork.Save();
        }
        public void EditOfflinePayment(OffLinePayment offlinepayment)
        {
            var oldpayment = _storeUnitOfWork.OfflinePaymentRepository.GetById(offlinepayment.Id);
            oldpayment.OrderId = offlinepayment.OrderId;
            _storeUnitOfWork.Save();
        }

        public OnlinePayment GetOnlinePayment(int id)
        {
            return _storeUnitOfWork.OnlinePaymentReposittory.GetById(id);
        }
        public OffLinePayment GetOfflinePayment(int id)
        {
            return _storeUnitOfWork.OfflinePaymentRepository.GetById(id);
        }

    }
}
