using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodOrdering.Models;
using FoodOrdering.Core.Services;

namespace FoodOrdering.Areas.Admin.Models
{
    public class FoodItemCategoryUpdateModel : BaseModel
    {
        public int ProductId { get; set; }
        public string FoodName { get; set; }
        public int  CategoryId { get; set; }
        public string CategoryName { get; set; }

        private IFoodItemCategoryService _fooditemcategoryService;
        private IFoodItemService _fooditemService;
        private ICategoryService _categoryService;
        public FoodItemCategoryUpdateModel()
        {
            _fooditemcategoryService = Startup.AutofacContainer.Resolve<IFoodItemCategoryService>();
            _fooditemService= Startup.AutofacContainer.Resolve<IFoodItemService>();
            _categoryService= Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public FoodItemCategoryUpdateModel(IFoodItemCategoryService fooditemcategoryService, IFoodItemService fooditemService,ICategoryService categoryService)
        {
            _fooditemcategoryService = fooditemcategoryService;
            _fooditemService = fooditemService;
            _categoryService = categoryService;
        }   

        public void AddNewFoodItemCategory()
        {
            try
            {
                var category = _categoryService.GetCategoryByName(CategoryName);
                var fooditem = _fooditemService.GetFoodItemByName(FoodName);
                _fooditemcategoryService.AddNewFoodItemCategory(new FoodItemCategory
                {
                    Category=category,
                    FoodItem=fooditem,
                    Foodname=this.FoodName,
                    CategoryName=this.CategoryName
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
    }
}
