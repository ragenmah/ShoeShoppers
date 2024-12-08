using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryDAL;

        public CategoryService(CategoryRepository categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }


        public void AddCategory(Category category)
        {
            _categoryDAL.AddCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryDAL.GetAllCategories();
        }

        public void UpdateCategory(Category category)
        {
            _categoryDAL.UpdateCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryDAL.DeleteCategory(categoryId);
        }
    }
}