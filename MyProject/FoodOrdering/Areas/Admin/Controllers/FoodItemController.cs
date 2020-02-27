using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Areas.Admin.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]


    public class FoodItemController : Controller
    {
        private IFoodItemService _fooditemService;
        public FoodItemController(IFoodItemService fooditemService)
        {
            _fooditemService = fooditemService;
        }
        public IActionResult Index()
        {
            var model = new FoodItemViewModel();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new FoodItemUpdateModel();
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(FoodItemUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewFoodItem();
            }
            return View(model);
        }

        public IActionResult GetFoodItems()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new FoodItemViewModel();
            var data = model.GetFooditems(tableModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new FoodItemUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new FoodItemViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FoodItemUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditFoodItem();
            }
            return View(model);
        }
    }
}