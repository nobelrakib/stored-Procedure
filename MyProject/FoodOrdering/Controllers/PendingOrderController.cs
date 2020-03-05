using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using FoodOrdering.Core.Entities;

namespace FoodOrdering.Controllers
{
    public class PendingOrderController : Controller
    {
        private readonly UserManager<ExtendedIdentityUser> _userManager;

        public PendingOrderController(UserManager<ExtendedIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("/PendingOrderController/AddPendingOrder",
         Name = "addorder")]
        public IActionResult AddPendingOrder(int fooditemid)
        {
              var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) RedirectToAction("Index");
            else
            {
                PendingOrderUpdateModel model1 = new PendingOrderUpdateModel()
                {
                    CustomerId = userId,
                    FoodItemId = fooditemid
                };
                model1.AddNewOrder();
                return View(model1);
            }
            PendingOrderUpdateModel model2 = new PendingOrderUpdateModel()
            {
                CustomerId = userId,
                
            };
            return View(model2);
            
        }
    }
}