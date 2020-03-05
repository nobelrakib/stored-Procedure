using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FoodOrdering.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Controllers
{
    public class MyOrdersController : Controller
    {
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderlist = new OrderModel();
            return View(orderlist.ListofOrder(userId));

        }
    }
}