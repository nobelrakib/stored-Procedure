using FoodOrdering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdering.Core.Services
{
    public interface IImageService
    {
        void AddImage(FoodImage foodimage);
        FoodImage GetFoodImage(int id);
    }
}
