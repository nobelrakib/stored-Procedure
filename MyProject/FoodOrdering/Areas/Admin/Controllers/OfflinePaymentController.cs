using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Areas.Admin.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;

namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OfflinePaymentController : Controller
    {
        private IPaymentService _paymentService;
        public OfflinePaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            var model = new OfflinePaymentViewModel();
            return View(model);
        }
        public IActionResult GetOffLinePayments()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new OfflinePaymentViewModel();
            var data = model.GetPayments(tableModel);
            return Json(data);
        }
    }
}