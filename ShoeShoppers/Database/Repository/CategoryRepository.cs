using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void AddCategory(Category category)
        {
            string query = @"INSERT INTO Categories (CategoryName, CategoryImageUrl, IsActive, CreatedAt) 
                             VALUES (@CategoryName, @CategoryImageUrl, @IsActive, GETDATE())";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@CategoryImageUrl", category.CategoryImageUrl);
                cmd.Parameters.AddWithValue("@IsActive", category.IsActive);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM Categories";
            var categories = new List<Category>();

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        CategoryId = reader.GetInt32(0),
                        CategoryName = reader.GetString(1),
                        CategoryImageUrl = reader.GetString(2),
                        IsActive = reader.GetBoolean(3),
                        CreatedAt = reader.GetDateTime(4)
                    });
                }
            }

            return categories;
        }

        public void UpdateCategory(Category category)
        {
            string query = @"UPDATE Categories 
                             SET CategoryName = @CategoryName, CategoryImageUrl = @CategoryImageUrl, IsActive = @IsActive 
                             WHERE CategoryId = @CategoryId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@CategoryImageUrl", category.CategoryImageUrl);
                cmd.Parameters.AddWithValue("@IsActive", category.IsActive);
                cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            string query = "DELETE FROM Categories WHERE CategoryId = @CategoryId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}