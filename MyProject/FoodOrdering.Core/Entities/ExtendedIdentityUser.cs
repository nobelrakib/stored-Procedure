using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Entities
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public IList<PendingOrder> PendingOrder { get; set; }
    }
}
