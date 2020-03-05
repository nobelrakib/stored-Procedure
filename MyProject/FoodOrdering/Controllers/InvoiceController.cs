using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Models;
using Microsoft.AspNetCore.Identity;
using FoodOrdering.Core.Entities;
using System.Linq;
namespace FoodOrdering.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly UserManager<ExtendedIdentityUser> _userManager;

        public InvoiceController(UserManager<ExtendedIdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = new InvoiceModel();
            //model.UserEmail(email);
            model.CreateInvoice(userId);
            return View(model);
        }
    }
}