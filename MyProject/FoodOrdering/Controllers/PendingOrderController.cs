using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Models;
namespace FoodOrdering.Controllers
{
    public class PendingOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/PendingOrderController/AddPendingOrder",
         Name = "addorder")]
        public IActionResult AddPendingOrder(int customerid,int fooditemid)
        {
            PendingOrderUpdateModel model = new PendingOrderUpdateModel()
            {
                CustomerId = customerid,
                FoodItemId = fooditemid
            };
            model.AddNewOrder();
            return View(model);
        }
    }
}