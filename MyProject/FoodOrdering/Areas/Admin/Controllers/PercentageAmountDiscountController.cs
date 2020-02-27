using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Areas.Admin.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class PercentageAmountDiscountController : Controller
    {
        
        private IPercentageAmountDiscountService _percentageamountdiscountService;
        public PercentageAmountDiscountController(IPercentageAmountDiscountService percentageamountdiscountService)
        {
            _percentageamountdiscountService = percentageamountdiscountService;
        }
        public IActionResult Index()
        {
            var model = new PercentageAmountDiscountViewModel();

            return View(model);
        }

        public IActionResult Add()
        {
            var model = new PercentageAmountDiscountUpdateModel();
            model.ListofFood();
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(PercentageAmountDiscountUpdateModel model)
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
            var model = new PercentageAmountDiscountViewModel();
            var data = model.GetFixedAmount(tableModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new PercentageAmountDiscountUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new PercentageAmountDiscountViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PercentageAmountDiscountUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditPercentageAmount();
            }
            return View(model);
        }
    }
}