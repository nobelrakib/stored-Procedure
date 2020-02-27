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

    public class FoodItemCategoryController : Controller
    {
        private IFoodItemCategoryService _fooditemcategoryService;
        public FoodItemCategoryController(IFoodItemCategoryService fooditemcategoryService)
        {
            _fooditemcategoryService = fooditemcategoryService;
        }
        public IActionResult Index()
        {
            var model = new FoodItemCategoryViewModel();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new FoodItemCategoryUpdateModel();
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(FoodItemCategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewFoodItemCategory();
            }
            return View(model);
        }

        public IActionResult GetFoodItemCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new FoodItemCategoryViewModel();
            var data = model.GetFooditemCategory(tableModel);
            return Json(data);
        }

        public IActionResult Edit([FromBody]int id1, int id2)
        {
            var model = new FoodItemCategoryUpdateModel();
            //model.Load(id1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id1,int id2)
        {
            var model = new FoodItemCategoryViewModel();
            //model.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FoodItemCategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                //model.EditFoodItem();
            }
            return View(model);
        }
    }
}