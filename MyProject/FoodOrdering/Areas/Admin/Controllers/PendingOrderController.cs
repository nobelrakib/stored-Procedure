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
using FoodOrdering.Core.Entities;
using FoodOrdering.DesignPatterns;
namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PendingOrderController : Controller
    {
        private IPendingOrderService _pendingorderService;
        private IConfirmedOrderService _confirmorderService;
        private ICustomerService _customerService;
        private IFoodItemService _foodService;
        public PendingOrderController(IPendingOrderService pendingorderService,
            IConfirmedOrderService confirmedorder,
            ICustomerService customerService,
            IFoodItemService fooditem
            )
        {
            _pendingorderService = pendingorderService;
            _confirmorderService = confirmedorder;
            _customerService = customerService;
            _foodService = fooditem;
        }
        public IActionResult Index()
        {
            var model = new PendingOrderViewModel();
            return View(model);
        }
        public IActionResult GetOrders()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new PendingOrderViewModel();
            var data = model.GetOrders(tableModel);
            return Json(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShifToConfirmedOrder(int id)
        {
            try
            {
                var pendingorder = _pendingorderService.GetPendingOrder(id);
                var customer = _customerService.GetCustomer(pendingorder.CustomerId);
                var fooditem = _foodService.GetFoodItem(pendingorder.FoodItemId);
                var confirmedorder = new ConfirmedOrder()
                {
                    FoodItem = fooditem,
                    Customer = customer
                };
                _pendingorderService.DeletePendingOrder(id);
                _confirmorderService.AddNewOrder(confirmedorder);
            }
            catch (InvalidOperationException iex)
            {

            }
            catch(Exception ex)
            {

            }
             return RedirectToAction("Index");
        }
    }
}