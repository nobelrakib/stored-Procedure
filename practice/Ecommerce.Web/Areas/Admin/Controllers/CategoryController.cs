using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Web.Areas.Admin.Models;
using Ecommerce.Web.Models;
using Ecommerce.Core.Services;
using Ecommerce.Core.Repositories;
using Ecommerce.Core.Entities;
namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
       // private ICategoryRepository _categoryrepository;
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
            //model.GetListOfCategory();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewCategory();
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new CategoryUpdateModel();
            model.Load(id);
            return View(model);
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
       // [Authorize(Policy = "InternalOfficials")]
        public IActionResult GetCategories()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CategoryViewModel();
            var data = model.GetCategories(tableModel);
            return Json(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new CategoryViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}