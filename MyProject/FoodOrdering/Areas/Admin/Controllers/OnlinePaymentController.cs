using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Areas.Admin.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;
namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OnlinePaymentController : Controller
    {
        private IPaymentService _paymentService;
        public OnlinePaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            var model = new OnlinePaymentViewModel();
            return View(model);
        }
        public IActionResult GetOnLinePayments()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new OnlinePaymentViewModel();
            var data = model.GetPayments(tableModel);
            return Json(data);
        }
        
    }
}