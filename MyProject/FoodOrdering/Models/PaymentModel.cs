using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;

namespace FoodOrdering.Models
{
    public class PaymentModel : BaseModel
    {
        public int OrderId { get; set; }
        public string CardNumber { get; set; }

        private IPendingOrderService _pendingorderService;

        private IConfirmedOrderService _confirmedorderService;

        private IPaymentService _paymentService;

        public PaymentModel()
        {
            _pendingorderService = Startup.AutofacContainer.Resolve<IPendingOrderService>();
            _confirmedorderService = Startup.AutofacContainer.Resolve<IConfirmedOrderService>();
            _paymentService = Startup.AutofacContainer.Resolve<IPaymentService>();
        }

        public PaymentModel(IPendingOrderService pendingorderService, 
            IConfirmedOrderService confirmedorderService,
            IPaymentService paymentService)
        {
            _pendingorderService = pendingorderService;
            _confirmedorderService = confirmedorderService;
            _paymentService = paymentService;
        }

        public void AddNewPayment()
        {
            try
            {
                var order = GetOrder(this.OrderId);
                if (CardNumber != null)
                {
                    _paymentService.AddOnlinePayment(new OnlinePayment
                    {
                        CardNumber=this.CardNumber,
                        Order=order
                    });
                    Notification = new NotificationModel("Success!", "Payment successfuly created", NotificationType.Success);
                }
                else
                {
                    _paymentService.AddOfflinePayment(new OffLinePayment
                    {
                        Order = order
                    });
                    Notification = new NotificationModel("Success!", "Payment successfuly created", NotificationType.Success);
                }
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to pay, please provide again",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to Pay, please try again",
                    NotificationType.Fail);
            }
        }
        public Order GetOrder(int id)
        {
          var pendingorder = _pendingorderService.GetPendingOrder(OrderId);
          var confirmedOrder = _confirmedorderService.GetConfirmedOrder(OrderId);
          if (pendingorder == null) return confirmedOrder;
          else return pendingorder;
        }
    }
}
