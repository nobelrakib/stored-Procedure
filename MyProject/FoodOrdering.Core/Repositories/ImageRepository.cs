using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Repositories
{
    public class ImageRepository : Repository<FoodImage>,IImageRepository
    {
        public ImageRepository(DbContext dbContext)
         : base(dbContext)
        {

        }
    }
}
