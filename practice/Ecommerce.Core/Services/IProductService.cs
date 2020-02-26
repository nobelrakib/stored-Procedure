using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Core.UnitOfWork;
using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered);
        void AddNewProduct(Product product);
        void AddNewProductCategory(ProductCategory productcategory);
        IEnumerable<ProductCategory> GetProductCategory(
         int pageIndex,
         int pageSize,
         string searchText,
         out int total,
         out int totalFiltered);
        Category GetCategory(int id);
        Product GetProduct(int id);
        Category GetCategory(string name);
        Product GetProduct(string name);
        void DeleteProduct(int id);
        void EditProduct(Product product);
        Category GetCategoryById(int id);
        void EditProductCategory(ProductCategory productcategory);
        void DeleteProductCategory(int id1, int id2);
    }
}
