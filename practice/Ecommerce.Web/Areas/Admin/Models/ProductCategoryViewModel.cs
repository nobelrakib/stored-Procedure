using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Web.Models;
using Ecommerce.Core.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Ecommerce.Web.Areas.Admin.Models
{
    public class ProductCategoryViewModel : BaseModel
    {
        private IProductService _productCategoryService;

        public ProductCategoryViewModel()
        {
            _productCategoryService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public ProductCategoryViewModel(IProductService productService)
        {
            _productCategoryService = productService;
        }

        public object GetProductCategory(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _productCategoryService.GetProductCategory(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.ProductId.ToString(),
                                record.CategoryId.ToString(),
                                record.CategoryName.ToString(),
                                record.ProductName.ToString()
                        }
                    ).ToArray()

            };

        }
        public void Delete(int id1,int id2)
        {
            _productCategoryService.DeleteProductCategory(id1, id2);
        }
    }
}
