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
    public class FixedAmountDiscountController : Controller
    {
        private IFixedAmountDiscountService _fixedamountdiscountService;
        public FixedAmountDiscountController(IFixedAmountDiscountService fixedamountdiscountService)
        {
            _fixedamountdiscountService = fixedamountdiscountService;
        }
        public IActionResult Index()
        {
            var model = new FixedAmountDiscountViewModel();
            
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new FixedAmountDiscountUpdateModel();
            model.ListofFood();
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(FixedAmountDiscountUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewFixedAmount();
                model.ListofFood();
            }
            return View(model);
        }

        public IActionResult GetAmounts()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new FixedAmountDiscountViewModel();
            var data = model.GetFixedAmount(tableModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new FixedAmountDiscountUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new FixedAmountDiscountViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FixedAmountDiscountUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditFixedAmount();
            }
            return View(model);
        }
    }
}