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
    public class ProductUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double price { get; set; }

        private IProductService _productService;

        public ProductUpdateModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public ProductUpdateModel(IProductService productService)
        {
            _productService = productService;
        }

        public void AddNewProduct()
        {
            try
            {
                _productService.AddNewProduct(new Product
                {
                    Name = this.Name,
                    Description=this.Description,
                    Price=this.price,     
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
