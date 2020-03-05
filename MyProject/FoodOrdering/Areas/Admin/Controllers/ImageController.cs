using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FoodOrdering.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        private IImageService _imageService;
        public ImageController()
        {
            _imageService= Startup.AutofacContainer.Resolve<IImageService>();
        }
        public IActionResult Index()
        {
            return View();
        }
       // public void AddImage()
    }
}