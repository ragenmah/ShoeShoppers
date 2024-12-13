using ShoeShoppers.Model;
using ShoeShoppers.Pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class ProductRepository
    {
        private readonly SqlConnection _connection;

        public ProductRepository()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            string query = "SELECT p.*, c.CategoryName FROM Products p " +
                "INNER JOIN Categories c ON p.CategoryId = c.CategoryId;";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            ProductDescription = reader["ProductDescription"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                            DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"]),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                            Size = reader["Size"].ToString(),
                            Color = reader["Color"].ToString(),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            CategoryName =reader["CategoryName"].ToString(),

                            ImageUrl = reader["ImageUrl"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        });
                    }
                }
            }

            return products;
        } 
        public List<Product> GetAllProductsByCategory(string categoryId)
        {
            var products = new List<Product>();
            string query = "SELECT p.*, c.CategoryName FROM Products p " +
                "INNER JOIN Categories c ON p.CategoryId = c.CategoryId WHERE p.CategoryId = @CategoryId ;";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            ProductDescription = reader["ProductDescription"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                            DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"]),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                            Size = reader["Size"].ToString(),
                            Color = reader["Color"].ToString(),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            CategoryName =reader["CategoryName"].ToString(),

                            ImageUrl = reader["ImageUrl"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        });
                    }
                }
            }

            return products;
        }

        public int AddProduct(Product product)
        {
            string query = "INSERT INTO Products (ProductName, ProductDescription, Price, DiscountPercentage, StockQuantity, Size, Color, CategoryId, ImageUrl, IsActive) " +
                           "VALUES (@ProductName, @ProductDescription, @Price, @DiscountPercentage, @StockQuantity, @Size, @Color, @CategoryId, @ImageUrl, @IsActive);" +
                           "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@DiscountPercentage", product.DiscountPercentage);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("@Size", product.Size);
                cmd.Parameters.AddWithValue("@Color", product.Color);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", product.IsActive);

                int productId = Convert.ToInt32(cmd.ExecuteScalar());
                if (productId == 0)
                    throw new Exception("Failed to retrieve the ProductId. Check database and query.");

                return productId;
            }
        }

        public void UpdateProduct(Product product)
        {
            string query = "UPDATE Products SET ProductName = @ProductName, ProductDescription = @ProductDescription, Price = @Price, " +
                           "DiscountPercentage = @DiscountPercentage, StockQuantity = @StockQuantity, Size = @Size, Color = @Color, " +
                           "CategoryId = @CategoryId, ImageUrl = @ImageUrl, IsActive = @IsActive, UpdatedAt = GETDATE() WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@DiscountPercentage", product.DiscountPercentage);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("@Size", product.Size);
                cmd.Parameters.AddWithValue("@Color", product.Color);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", product.IsActive);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int productId)
        {
            string query = "DELETE FROM Products WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.ExecuteNonQuery();
            }
         }


        public Product GetProductById(int id)
        {
            Product product = null;
            string query = "SELECT * FROM Products WHERE ProductId = @ProductId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            ProductDescription = reader["ProductDescription"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                            DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"]),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                            Size = reader["Size"].ToString(),
                            Color = reader["Color"].ToString(),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };
                    }
                }
            }

            return product;
        }
    }
}