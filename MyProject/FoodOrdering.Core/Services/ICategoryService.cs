﻿using System;
using System.Collections.Generic;
using System.Text;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered);
        void AddNewCategory(Category category);
    }
}