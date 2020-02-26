using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Ecommerce.Core.UnitOfWork;
using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Services
{
    public class ProductService : IProductService

    {
        private IStoreUnitOfWork _storeUnitOfWork;

        public ProductService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }
        public void AddNewProduct(Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Name))
                throw new InvalidOperationException("Product name is missing");

            _storeUnitOfWork.ProductRepository.Add(product);
            _storeUnitOfWork.Save();
        }
        public IEnumerable<Product> GetProducts(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered)
        {
            return _storeUnitOfWork.ProductRepository.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public IEnumerable<ProductCategory> GetProductCategory(
          int pageIndex,
          int pageSize,
          string searchText,
          out int total,
          out int totalFiltered)
        {
            return _storeUnitOfWork.ProductCategoryRepository.Get(
                out total,
                out totalFiltered,
                x => x.ProductName.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }
        public void AddNewProductCategory(ProductCategory productcategory)
        {
            if (productcategory == null || string.IsNullOrWhiteSpace(productcategory.ProductName))
                throw new InvalidOperationException("Product name is missing");

            _storeUnitOfWork.ProductCategoryRepository.Add(productcategory);
            _storeUnitOfWork.Save();
        }
        public Category GetCategory(int id)
        {
            return _storeUnitOfWork.CategoryRepository.GetById(id);
        }
        public Product GetProduct(int id)
        {
            return _storeUnitOfWork.ProductRepository.GetById(id);
        }
        public Product GetProduct(string name)
        {
            return _storeUnitOfWork.ProductRepository.GetProductByName(name);
        }
        public Category GetCategory(string name)
        {
            return _storeUnitOfWork.CategoryRepository.GetCategoryByName(name);
        }
        public void DeleteProduct(int id)
        {
            _storeUnitOfWork.ProductRepository.Remove(id);
            _storeUnitOfWork.Save();
        }
        public void DeleteProductCategory(int id1,int id2)
        {
            _storeUnitOfWork.ProductCategoryRepository.RemovePc(id1,id2);
            _storeUnitOfWork.Save();
        }

        public void EditProduct(Product product)
        {
            var oldproduct = _storeUnitOfWork.ProductRepository.GetById(product.Id);
            oldproduct.Name = product.Name;
            _storeUnitOfWork.Save();
        }
        public void EditProductCategory(ProductCategory productcategory)
        {
            var oldproductcategory = _storeUnitOfWork.ProductCategoryRepository.GetById(productcategory.CategoryId);
            oldproductcategory.ProductName = productcategory.ProductName;
            _storeUnitOfWork.Save();
        }
        public Category GetCategoryById(int id)
        {
            return _storeUnitOfWork.CategoryRepository.GetById(id);
        }




    }
}
