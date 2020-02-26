using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Contexts;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Core.UnitOfWork;
using System.Security.Claims;
using Ecommerce.Core.Contexts;
using Microsoft.AspNetCore.Http;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Web.Models
{
    public class Test
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        private readonly IStoreUnitOfWork _storeUnitofWork;
        
        [EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
        public Test()
        {
            _storeUnitofWork= Startup.AutofacContainer.Resolve<IStoreUnitOfWork>();
           // _httpContextAccessor = httpContextAccessor;
        }
        //public Test(IHttpContextAccessor httpContextAccessor,
        //    UserManager<ExtendedIdentityUser> userManager,
        //    IStoreUnitOfWork storeUnitofWork)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //    _userManager = userManager;
        //    _storeUnitofWork = storeUnitofWork;
        //}
        public void something(string userId)
        {
             //userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userName = User.FindFirstValue(ClaimTypes.Name);
            //var user = UserManager.Users.
           // var a = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            
            var order = new Order2()
            {
                UserId = userId
            };

            _storeUnitofWork.OrderRepository.Add(order);
            //if (order.Id < 0) order.Id = -1 * order.Id;
            _storeUnitofWork.Save();
        }
    }
}
