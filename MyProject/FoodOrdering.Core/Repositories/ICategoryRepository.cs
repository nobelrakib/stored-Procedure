using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
using FoodOrdering.Data;
namespace FoodOrdering.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category SearchByCategoryName(string name);
    }
}
