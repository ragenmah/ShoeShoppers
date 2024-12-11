using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class CartRepository
    {
        private readonly SqlConnection _connection;

        public CartRepository()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }


        public void AddCart(Cart cart)
        {


            string query = "INSERT INTO Cart (ProductId, Quantity, UserId) VALUES (@ProductId, @Quantity, @UserId)";



            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", cart.ProductId);
                cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                cmd.Parameters.AddWithValue("@UserId", cart.UserId);

                cmd.ExecuteNonQuery();
            }
        }

        public bool IsProductInCart(int productId, int userId)
        {
            string query = "SELECT COUNT(*) FROM Cart WHERE ProductId = @ProductId AND UserId = @UserId";
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public List<Cart> GetAllCarts()
        {
            string query = "SELECT * FROM Cart";
            var carts = new List<Cart>();

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    carts.Add(new Cart
                    {
                        CartId = (int)reader["CartId"],
                        ProductId = (int)reader["ProductId"],
                        Quantity = (int)reader["Quantity"],
                        UserId = (int)reader["UserId"],
                        CreatedAt = (DateTime)reader["CreatedAt"]
                    });
                }
            }

            return carts;
        }

        public List<Cart> GetCartItemsByUser(int userId)
        {
            string query = "SELECT c.CartId, c.ProductId, c.Quantity, p.ProductName, p.Price, p.DiscountPercentage, p.DiscountedPrice, " +
                "p.StockQuantity, p.ImageUrl, p.IsActive " +
                "FROM Cart c JOIN Products p " +
                "ON c.ProductId = p.ProductId " +
                "WHERE c.UserId = @UserId;";


            var carts = new List<Cart>();

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        carts.Add(new Cart
                        {
                            CartId = (int)reader["CartId"],
                            ProductId = (int)reader["ProductId"],
                            ProductName = (string)reader["ProductName"],

                            Price = Convert.ToDecimal(reader["Price"]),
                            DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                            DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"]),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                            TotalPrice= Convert.ToDecimal(reader["DiscountedPrice"]) * Convert.ToDecimal(reader["Quantity"]),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            Quantity = (int)reader["Quantity"]
                           
                        });
                    }
                }
            }

            return carts;
        }

        public void UpdateCart(Cart cart)
        {
            string query = "UPDATE Cart SET ProductId = @ProductId, Quantity = @Quantity, UserId = @UserId  WHERE ProductId = @ProductId AND UserId = @UserId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@CartId", cart.CartId);
                cmd.Parameters.AddWithValue("@ProductId", cart.ProductId);
                cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                cmd.Parameters.AddWithValue("@UserId", cart.UserId);

                cmd.ExecuteNonQuery();
            }
        }

        public void AddOrUpdateCart(Cart cart)
        {
            if (IsProductInCart(cart.ProductId, cart.UserId))
            {

                UpdateCart(cart);
            }
            else
            {

                AddCart(cart);
            }
        }

        public void DeleteCart(int cartId)
        {
            string query = "DELETE FROM Cart WHERE CartId = @CartId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@CartId", cartId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}