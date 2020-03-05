using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;
using FoodOrdering.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;

namespace FoodOrdering.Areas.Admin.Models
{
    public class FoodItemUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  int FoodItemId { get; set; }
        public double price { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public IList<FoodItem> FoodList { get; set; }
        public IList<Category> CategoryList { get; set; }
        public Category Category { get; set; }
        private IFoodItemService _fooditemService;
        private IImageService _imageService;
        public string[] Categories { get; set; }
        private ICategoryService _categoryService;
        public IFormFile profileImage { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public FoodItemUpdateModel()
        {
            _fooditemService = Startup.AutofacContainer.Resolve<IFoodItemService>();
            _imageService = Startup.AutofacContainer.Resolve<IImageService>();
            _categoryService= Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public FoodItemUpdateModel(IFoodItemService fooditemService,
            IImageService imageService,ICategoryService categoryService
            )
        {
            _fooditemService = fooditemService;
            _imageService = imageService;
            _categoryService = categoryService;
        }

        public void AddNewFoodItem()
        {
            try
            {
                var fooditem = new FoodItem
                {
                    Name = this.Name,
                    Price = this.price,
                    Description = this.Description,
                    CategoryId=Category.Id
                };
                _fooditemService.AddNewFoodItem(fooditem);
                FoodItemId = fooditem.Id;
                _imageService.AddImage(new FoodImage
                {
                    Url = FileName,
                    FoodItemId=this.FoodItemId

                });

                Notification = new NotificationModel("Success!", "FoodItem successfuly created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create FoodItem, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create FoodItem, please try again",
                    NotificationType.Fail);
            }
        }

        public void GetDropDownList()
        {
            this.CategoryList = _categoryService.GetCategoryList();
          //  this.CategoryList = this.CategoryList.Select(cl => new Category { Name = cl.Name, Id = cl.Id }).ToList();
        }

        public void EditFoodItem()
        {
            try
            { 
                 _fooditemService.EditFoodItem(new FoodItem
                {
                    Id = this.Id,
                     Name = this.Name,
                     Price = this.price,
                     Description = this.Description

                 });

                Notification = new NotificationModel("Success!", "Category successfuly updated", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please try again",
                    NotificationType.Fail);
            }
        }

        public void Load(int id)
        {
            var fooditem = _fooditemService.GetFoodItem(id);
            if (fooditem != null)
            {
                Id = fooditem.Id;
                Name = fooditem.Name;
                price = fooditem.Price;
                Description = fooditem.Description;
            }
        }
        public void FileUpload(IFormFile profileImage)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(profileImage.FileName);
            var newFileName = $"{ randomName }{ Path.GetExtension(profileImage.FileName)}";
            FileName = newFileName;
            var path = $"wwwroot/upload/{randomName}{Path.GetExtension(profileImage.FileName)}";
            FilePath = path;
            if (!System.IO.File.Exists(path))
            {
                using (var imageFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = profileImage.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageFile);

                    }
                }
            }
        }
        public void ListofFood() => FoodList = _fooditemService.GetFoodItemList();
    }
}
