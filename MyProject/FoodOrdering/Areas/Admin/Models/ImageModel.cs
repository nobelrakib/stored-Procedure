using Autofac;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Areas.Admin.Models
{
    public class ImageModel
    {
        public string FoodItemId { get; set; }
        public string Url { get; set; }

        private IFoodItemService _fooditemService;

        private IImageService _imageService;
        public ImageModel()
        {
            _imageService = Startup.AutofacContainer.Resolve<IImageService>();
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
        }
       
    }
}
