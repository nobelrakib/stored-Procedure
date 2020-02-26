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
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productservice)
        {
            _productService = productservice;
        }

        public IActionResult Index()
        {
            var model = new ProductViewModel();
            return View(model);
        }
        public IActionResult GetProduct()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductViewModel();
            var data = model.GetProducts(tableModel);
            return Json(data);
        }

        public IActionResult Add()
        {
            var model = new ProductUpdateModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewProduct();
            }
            return View(model);
        }
    }
}