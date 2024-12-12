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

        public int AddOrder(Order order)
        {
            var query = "INSERT INTO Orders (OrderNumber, UserId, Status,  PaymentId, OrderDate) " +
                "VALUES (@OrderNumber, @UserId, @Status,  @PaymentId, GETDATE());" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                cmd.Parameters.AddWithValue("@UserId", order.UserId);
                cmd.Parameters.AddWithValue("@Status", order.Status);
                cmd.Parameters.AddWithValue("@PaymentId", order.PaymentId);

                int orderId = Convert.ToInt32(cmd.ExecuteScalar());
                if (orderId == 0)
                    throw new Exception("Failed to retrieve the orderId. Check database and query.");

                return orderId;
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

        public Order GetOrderDetailsById(int orderId, int userId)
        {
            string query = "SELECT O.OrderId, O.OrderNumber, O.Status AS OrderStatus, O.OrderDate, O.IsCancelled, U.UserId, U.FirstName, U.LastName, U.Email, U.MobileNumber, U.Address AS UserAddress, U.City AS UserCity, U.PostalCode AS UserPostalCode, U.Country AS UserCountry, P.PaymentId, P.OwnerName AS PaymentOwner, P.CardNo AS PaymentCardNumber, P.ExpiryDate AS PaymentExpiryDate, P.CvvNo AS PaymentCvv, P.BillingAddress AS PaymentBillingAddress, P.PaymentMethod " +
                "FROM Orders O JOIN Users U ON O.UserId = U.UserId JOIN Payment P ON O.PaymentId = P.PaymentId " +
                "WHERE O.UserId = @UserId AND O.OrderId = @OrderId ";

            Order order = null;

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                     order = new Order
                    {
                        OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                        OrderNumber = reader.GetString(reader.GetOrdinal("OrderNumber")),
                        Status = reader.GetString(reader.GetOrdinal("OrderStatus")),
                        OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                        IsCancelled = reader.GetBoolean(reader.GetOrdinal("IsCancelled")),
                        User = new User
                        {
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            MobileNumber = reader.GetString(reader.GetOrdinal("MobileNumber")),
                            Address = reader.GetString(reader.GetOrdinal("UserAddress")),
                            City = reader.GetString(reader.GetOrdinal("UserCity")),
                            PostalCode = reader.GetString(reader.GetOrdinal("UserPostalCode")),
                            Country = reader.GetString(reader.GetOrdinal("UserCountry"))
                        },
                        Payment = new Payment
                        {
                            PaymentId = reader.GetInt32(reader.GetOrdinal("PaymentId")),
                            OwnerName = reader.GetString(reader.GetOrdinal("PaymentOwner")),
                            CardNo = reader.GetString(reader.GetOrdinal("PaymentCardNumber")),
                            ExpiryDate = reader.GetString(reader.GetOrdinal("PaymentExpiryDate")),
                            CvvNo = reader.GetInt32(reader.GetOrdinal("PaymentCvv")),
                            BillingAddress = reader.GetString(reader.GetOrdinal("PaymentBillingAddress")),
                            PaymentMethod = reader.GetString(reader.GetOrdinal("PaymentMethod"))
                        }
                    };
                }
            }

            return order;
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