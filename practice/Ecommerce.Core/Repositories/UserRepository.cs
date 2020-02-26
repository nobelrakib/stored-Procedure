using Ecommerce.Core.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Core.Repositories
{
    public class UserRepository
    {
        private StoreContext _context;
        public UserRepository(StoreContext context)
        {
            _context = context;
        }
        //public string GetUserId()
        //{
        //    var userId= HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    return _context.Users.
        //}
    }
}
