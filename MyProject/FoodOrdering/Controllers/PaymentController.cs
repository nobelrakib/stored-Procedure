using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;

namespace FoodOrdering.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPayment()
        {
            var model = new PaymentModel();
            model.AddNewPayment();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddPayment(PaymentModel model)
        {
            if (ModelState.IsValid) 
            {
                model.AddNewPayment();
            }
            return View(model);
        }

    }
}