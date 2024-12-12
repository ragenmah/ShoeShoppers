using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class OrderItemRepository
    {
        private readonly SqlConnection _connection;

        public OrderItemRepository()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }

        public void AddOrderItems(OrderItem orderItem)
        {
            var query = "INSERT INTO OrderItems (OrderId, ProductId, Quantity, UnitPrice) VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice)";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
                cmd.Parameters.AddWithValue("@ProductId", orderItem.ProductId);
                cmd.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                cmd.Parameters.AddWithValue("@UnitPrice", orderItem.UnitPrice);
                cmd.ExecuteNonQuery();
            }
        }

        public List<OrderItem> GetOrderItems(int orderId)

        {
            var query = "SELECT oi.OrderItemId, oi.OrderId, oi.Quantity, oi.UnitPrice, p.ProductId, p.ProductName, p.Price, p.DiscountPercentage, p.DiscountedPrice, p.StockQuantity, p.Size," +
                " p.Color, p.ImageUrl FROM OrderItems oi JOIN Products p ON oi.ProductId = p.ProductId WHERE oi.OrderId = @OrderId;";
         
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);

            
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    orderItems.Add(new OrderItem
                    {
                        OrderItemId = (int)reader["OrderItemId"],
                        OrderId = (int)reader["OrderId"],
                        ProductId = (int)reader["ProductId"],
                        Quantity = (int)reader["Quantity"],
                        UnitPrice = (decimal)reader["UnitPrice"],
                        Product= new Product {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                            DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"]),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                        } 
                    });
                }
            }
            }

            return orderItems;
        }

        
        public void UpdateOrderItem(OrderItem orderItem)
        {
            var query = "UPDATE OrderItems SET ProductId = @ProductId, Quantity = @Quantity, UnitPrice = @UnitPrice WHERE OrderItemId = @OrderItemId";


            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderItemId", orderItem.OrderItemId);
                cmd.Parameters.AddWithValue("@ProductId", orderItem.ProductId);
                cmd.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                cmd.Parameters.AddWithValue("@UnitPrice", orderItem.UnitPrice);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteOrderItem(int orderItemId)
        {
            var query = "DELETE FROM OrderItems WHERE OrderItemId = @OrderItemId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderItemId", orderItemId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}