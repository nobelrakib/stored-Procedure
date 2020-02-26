using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Core.Entities
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public IList<Order2> Orders { get; set; }
        public string City { get; set; }
        
        //public string City { get; set; }
    }
}
