using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Core.Contexts
{
    public interface IFoodStoreContext
    {
         DbSet<FoodItem> FoodItems { get; set; }
         DbSet<FoodImage> FoodImages { get; set; }
         DbSet<Category> Category { get; set; }
       //  DbSet<FoodItemCategory> FoodItemCategory { get; set; }
         DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
         DbSet<PercentageAmountDiscount> PercentageDiscounts { get; set; }
    }
}
