using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Web.Areas.Admin.Models;
using Ecommerce.Web.Models;
using Ecommerce.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductCategoryController : Controller
    {
        private IProductService _productcategoryService;
        public ProductCategoryController(IProductService productcategoryservice)
        {
            _productcategoryService = productcategoryservice;
        }

        public IActionResult Index()
        {
            var model = new ProductCategoryViewModel();
            return View(model);
        }
        public IActionResult GetProductCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductCategoryViewModel();
            var data = model.GetProductCategory(tableModel);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new ProductCategoryUpdateModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductCategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewProductCategory();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id1,int id2)
        {
            var model = new ProductCategoryViewModel();
            model.Delete(id1,id2);
            return RedirectToAction("Index");
        }

    }
}