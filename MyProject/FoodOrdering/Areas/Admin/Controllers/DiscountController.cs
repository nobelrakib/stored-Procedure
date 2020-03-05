using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class DiscountController : Controller
    {
        public IActionResult Index(int id)
        {
            return RedirectToAction("Add", "Discount", new { area = "Admin", id = id });
        }
        public IActionResult Add(int id)
        {
            var model = new DiscountUpdateModel();
            model.InitializeDiscountListName();
            model.InitializeId(id);
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(DiscountUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var id = model.GetId();
                model.InitializeDiscountListName();
                model.AddDiscount(id);
                // model.ListofFood();
            }
            return View(model);
        }
    }
}