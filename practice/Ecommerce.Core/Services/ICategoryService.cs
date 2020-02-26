using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Core.Services
{
    public interface ICategoryService
    {
       IEnumerable<Category> GetCategories(
            int pageIndex,
            int pageSize,
            string searchText,
             int total,
             int totalFiltered);
        void AddNewCategory(Category category);
        void DeleteCategory(int id);
        void EditCategory(Category category);
        Category GetCategory(int id);
        List<Category> GetList();

    }

}
