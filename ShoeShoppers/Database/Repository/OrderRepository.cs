using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class OrderRepository
    {
        private readonly SqlConnection _connection;

        public OrderRepository()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }

        public void AddOrder(Order order)
        {
            var query = "INSERT INTO Orders (OrderNumber, UserId, Status, CvvNo, PaymentId, OrderDate) VALUES (@OwnerName, @CardNo, @ExpiryDate, @CvvNo, @BillingAddress, @PaymentMethod)";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                cmd.Parameters.AddWithValue("@UserId", order.UserId);
                cmd.Parameters.AddWithValue("@Status", order.Status);
                cmd.Parameters.AddWithValue("@PaymentId", order.PaymentId);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Order> GetAllOrders()
        {
            var query = "SELECT * FROM Orders";
            List<Order> orders = new List<Order>();

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderId = (int)reader["OrderId"],
                        OrderNumber = reader["OrderNumber"].ToString(),
                        UserId = (int)reader["UserId"],
                        Status = reader["Status"].ToString(),
                        PaymentId = (int)reader["PaymentId"],
                        OrderDate = (DateTime)reader["OrderDate"],
                        IsCancelled = (bool)reader["IsCancelled"]
                    });
                }
            }

            return orders;
        }

        public Payment GetOrderById(string orderId)
        {
            string query = "SELECT * FROM ProductImages WHERE ProductId = @ProductId";
            Payment payment = null;

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {

                cmd.Parameters.AddWithValue("@PaymentId", orderId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    payment = new Payment
                    {
                        PaymentId = (int)reader["PaymentId"],
                        OwnerName = reader["OwnerName"].ToString(),
                        CardNo = reader["CardNo"]?.ToString(),
                        ExpiryDate = reader["ExpiryDate"]?.ToString(),
                        CvvNo = reader["CvvNo"] as int?,
                        BillingAddress = reader["BillingAddress"]?.ToString(),
                        PaymentMethod = reader["PaymentMethod"].ToString()
                    };
                }
            }

            return payment;
        }

        public void UpdateOrders(Payment payment)
        {
            var query = "UPDATE Payment SET OwnerName = @OwnerName, CardNo = @CardNo, ExpiryDate = @ExpiryDate, CvvNo = @CvvNo, BillingAddress = @BillingAddress, PaymentMethod = @PaymentMethod WHERE PaymentId = @PaymentId";


            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@PaymentId", payment.PaymentId);
                cmd.Parameters.AddWithValue("@OwnerName", payment.OwnerName);
                cmd.Parameters.AddWithValue("@CardNo", payment.CardNo);
                cmd.Parameters.AddWithValue("@ExpiryDate", payment.ExpiryDate);
                cmd.Parameters.AddWithValue("@CvvNo", payment.CvvNo);
                cmd.Parameters.AddWithValue("@BillingAddress", payment.BillingAddress);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteOrder(int orderId)
        {
            var query = "DELETE FROM Orders WHERE OrderId = @OrderId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}