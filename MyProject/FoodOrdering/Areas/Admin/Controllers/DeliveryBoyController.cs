using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Areas.Admin.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DeliveryBoyController : Controller
    {
        private IDeliveryService _deliveryService;
        public DeliveryBoyController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }
        public IActionResult Index()
        {
            var model = new DeliveryBoyViewModel();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new DeliveryBoyUpdateModel();
            
            return View(model);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult Add(DeliveryBoyUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewDeliveryBoy();
                
            }
            return View(model);
        }

        public IActionResult GetDeliveries()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new DeliveryBoyViewModel();
            var data = model.GetDeliveries(tableModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new DeliveryBoyUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new DeliveryBoyViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DeliveryBoyUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditDeliveryBoy();
            }
            return View(model);
        }
    }
}