using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ecommerce.Core.Contexts;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Core.UnitOfWork;
using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Web.Controllers
{
    public class ATController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        private readonly IStoreUnitOfWork _storeUnitofWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ATController(UserManager<ExtendedIdentityUser> userManager,
            IStoreUnitOfWork storeUnitofWork,IHttpContextAccessor httpContextAccessor)
        {
            _userManager = Startup.AutofacContainer.Resolve<UserManager<ExtendedIdentityUser>>();
            _storeUnitofWork = storeUnitofWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public void YN()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            //var user = UserManager.Users.
            var a = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            var order = new Order2()
            {
                UserId = a.Id
            };

            _storeUnitofWork.OrderRepository.Add(order);
            //if (order.Id < 0) order.Id = -1 * order.Id;
            _storeUnitofWork.Save();
            // order.Customer = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            ///ExtendedIdentityUser applicationUser =  _userManager.GetUser(User);
            //string userEmail = applicationUser?.Email; // will give the user's Email
        }
        [Authorize(Roles = "Support")]
        public void ST()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var s = new Test();
            s.something(userId);

        }
    }
}