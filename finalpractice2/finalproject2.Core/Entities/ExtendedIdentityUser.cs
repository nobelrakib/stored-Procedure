using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace finalproject2.Core.Entities
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public string City { get; set; }
    }
}
