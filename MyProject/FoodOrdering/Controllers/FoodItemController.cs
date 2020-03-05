using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Models;
using System.Security.Claims;

namespace FoodOrdering.Controllers
{
    public class FoodItemController : Controller
    {
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var fooditemmodellist = new FoodItemModel();
            fooditemmodellist.InitiateUser(userId);
            return View(fooditemmodellist.ListofFoodItemModel());
        }
    }
}