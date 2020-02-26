using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Web.Models;
using Ecommerce.Core.Services;
using Ecommerce.Core.Entities;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Ecommerce.Web.Areas.Admin.Models
{
    public class ProductCategoryUpdateModel : BaseModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }

        private IProductService _productcategoryService;

        public ProductCategoryUpdateModel()
        {
            _productcategoryService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public ProductCategoryUpdateModel(IProductService productcategoryService)
        {
            _productcategoryService = productcategoryService;
        }

        public void AddNewProductCategory()
        {
            try
            {
                Category category = _productcategoryService.GetCategory(CategoryName);
                Product product = _productcategoryService.GetProduct(ProductName);
                _productcategoryService.AddNewProductCategory(new ProductCategory
                {
                    Category = category,
                    Product = product,
                    CategoryName = this.CategoryName,
                    ProductName = this.ProductName
                }) ;

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
        public void EditCategory()
        {
            try
            {
                Category category = _productcategoryService.GetCategory(CategoryName);
                Product product = _productcategoryService.GetProduct(ProductName);

                _productcategoryService.EditProductCategory(new ProductCategory
                {
                    Category = category,
                    Product = product,
                    CategoryName = this.CategoryName,
                    ProductName = this.ProductName

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

        //public void Load(int id)
        //{
        //    var Productcategory = _productcategoryService.GetProductCategory(id);
        //    if (Productcategory != null)
        //    {
        //        ProductId=
        //    }
        //}
    }
}
