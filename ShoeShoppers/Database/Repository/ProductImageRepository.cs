using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class ProductImageRepository
    {
        private SqlConnection connection = DatabaseConnection.Instance.GetConnection();

        // CREATE
        public void AddProductImage(ProductImage productImage)
        {
            string query = "INSERT INTO ProductImages (ProductId, ImageUrl) VALUES (@ProductId, @ImageUrl)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productImage.ProductId);
                cmd.Parameters.AddWithValue("@ImageUrl", productImage.ImageUrl);
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<ProductImage> GetImagesByProductId(string productId)
        {
            string query = "SELECT * FROM ProductImages WHERE ProductId = @ProductId";
            List<ProductImage> images = new List<ProductImage>();

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductImage image = new ProductImage
                    {
                        ImageId = (int)reader["ImageId"],
                        ProductId = (int)reader["ProductId"],
                        ImageUrl = reader["ImageUrl"].ToString(),
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    };
                    images.Add(image);
                }
            }

            return images;
        }

        // UPDATE
        public void UpdateProductImage(ProductImage productImage)
        {
            string query = "UPDATE ProductImages SET ImageUrl = @ImageUrl WHERE ImageId = @ImageId";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ImageUrl", productImage.ImageUrl);
                cmd.Parameters.AddWithValue("@ImageId", productImage.ImageId);
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteProductImage(int imageId)
        {
            string query = "DELETE FROM ProductImages WHERE ImageId = @ImageId";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ImageId", imageId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}