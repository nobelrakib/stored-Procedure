using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Core.Entities;
namespace Ecommerce.Core.Contexts
{
    public interface IStoreContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }
        DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
        DbSet<PercentageDiscount> PercentageDiscounts { get; set; }
        DbSet<Order2> Order { get; set; }
    }
}
