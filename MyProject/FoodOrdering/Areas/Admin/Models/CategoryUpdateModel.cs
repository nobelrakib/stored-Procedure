using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FoodOrdering.Core.Entities;
using FoodOrdering.Core.Services;
namespace FoodOrdering.Areas.Admin.Models
{
    public class CategoryUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private ICategoryService _categoryService;

        public CategoryUpdateModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public CategoryUpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void AddNewCategory()
        {
            try
            {
                _categoryService.AddNewCategory(new Category
                {
                    Name = this.Name
                });

                Notification = new NotificationModel("Success!", "Category successfuly created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please try again",
                    NotificationType.Fail);
            }
        }
    }
}
