using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Models;
namespace FoodOrdering.Controllers
{
    public class FoodItemController : Controller
    {
        public IActionResult Index()
        {
            var fooditemmodellist = new FoodItemModel();
            return View(fooditemmodellist.ListofFoodItemModel());
        }
    }
}