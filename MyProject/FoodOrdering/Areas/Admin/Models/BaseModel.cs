using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Areas.Admin.Models
{
    public abstract class BaseModel
    {
        public NotificationModel Notification { get; set; }
    }
}
