using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrdering.Areas.Admin.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace FoodOrdering.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]


    public class FoodItemController : Controller
    {
        private IFoodItemService _fooditemService;
        public FoodItemController(IFoodItemService fooditemService)
        {
            _fooditemService = fooditemService;
        }
        public IActionResult Index()
        {
            var model = new FoodItemViewModel();
            
            return View(model);
        }

        public IActionResult Index2(int id)
        {
            var model = new FoodItemViewModel();
            //TempData["id"] = id;
            return View(model);
           // return RedirectToAction("GetParticularFoodItems");
        }
        public IActionResult Add()
        {
            var model = new FoodItemUpdateModel();
            model.GetDropDownList();
            return View(model);
        }

        [HttpPost]
        
        public IActionResult Add(FoodItemUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.FileUpload(model.profileImage);
                model.GetDropDownList();
                model.AddNewFoodItem();
                
            }
          //  model.GetDropDownList();
            return View(model);
        }
        public IActionResult CallDiscount(int id)
        {
            return RedirectToAction("Index", "Discount", new { area = "Admin", id = id });
        }
        [HttpPost]
        public async Task AddImage(IFormFile profileImage)
        {
            var model = new AwsModel();
            var fooditemmodel = new FoodItemUpdateModel();
            model.FileUpload(profileImage);
            await model.AddPictureInS3Bucket();
            await model.AddinInQueue();
            fooditemmodel.Url = model.FileName;
            //fooditemmodel.AddImage();
        }

        public IActionResult GetFoodItems()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new FoodItemViewModel();
            var data = model.GetFooditems(tableModel);
            return Json(data);
        }
        [HttpGet]
        public IActionResult GetParticularFoodItems()
        {

           // var categoryIdString = TempData["id"].ToString();
           // var categoryId = int.Parse(categoryIdString);
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new FoodItemViewModel();
            var id = model.GetId();
            var data = model.GetParticularFooditems(tableModel,id);
            return Json(data);
        }

        //public IActionResult OrderDetails(int id)
        //{
        //    var tableModel = new DataTablesAjaxRequestModel(Request);
        //    var model = new FoodItemViewModel();
        //    var data = model.GetFooditems(tableModel);
        //    return Json(data);
        //}
        public IActionResult Edit(int id)
        {
            var model = new FoodItemUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new FoodItemViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FoodItemUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditFoodItem();
            }
            return View(model);
        }
    }
}