using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace FoodOrdering.Core.Repositories
{
    public interface IOnlinePaymentRepository : IRepository<OnlinePayment>
    {

    }
}
