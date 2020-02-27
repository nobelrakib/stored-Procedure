using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Areas.Admin.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;
namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var model = new CategoryViewModel();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new CategoryUpdateModel();
            model.ListofFood();
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(CategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewCategory();
                model.ListofFood();
            }
            return View(model);
        }

        public IActionResult GetCategories()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CategoryViewModel();
            var data = model.GetCategories(tableModel);
            return Json(data);
        }

        public IActionResult Edit(int id)
        {
            var model = new CategoryUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new CategoryViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditCategory();
            }
            return View(model);
        }
    }
}