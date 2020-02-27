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
    public class ConfirmedOrderController : Controller
    {
        private IConfirmedOrderService _confirmedorderService;
        public ConfirmedOrderController(IConfirmedOrderService confirmedorderService)
        {
            _confirmedorderService = confirmedorderService;
        }
        public IActionResult Index()
        {
            var model = new ConfirmedOrderViewModel();
            return View(model);
        }
        public IActionResult GetOrders()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ConfirmedOrderViewModel();
            var data = model.GetOrders(tableModel);
            return Json(data);
            //return View(model);
        }
    }
}