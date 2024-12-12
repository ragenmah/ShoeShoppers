using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class PaymentRepository
    {
        private readonly SqlConnection _connection;

        public PaymentRepository()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }

        public void AddPayment(Payment payment)
        {
            var query = "INSERT INTO Payment (OwnerName, CardNo, ExpiryDate, CvvNo, BillingAddress, PaymentMethod) VALUES (@OwnerName, @CardNo, @ExpiryDate, @CvvNo, @BillingAddress, @PaymentMethod)";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OwnerName", payment.OwnerName);
                cmd.Parameters.AddWithValue("@CardNo", payment.CardNo);
                cmd.Parameters.AddWithValue("@ExpiryDate", payment.ExpiryDate);
                cmd.Parameters.AddWithValue("@CvvNo", payment.CvvNo);
                cmd.Parameters.AddWithValue("@BillingAddress", payment.BillingAddress);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Payment> GetAllPayments()
        {
            var query = "SELECT * FROM Payment";
            var payments = new List<Payment>();

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    payments.Add(new Payment
                    {
                        PaymentId = (int)reader["PaymentId"],
                        OwnerName = reader["OwnerName"].ToString(),
                        CardNo = reader["CardNo"]?.ToString(),
                        ExpiryDate = reader["ExpiryDate"]?.ToString(),
                        CvvNo = reader["CvvNo"] as int?,
                        BillingAddress = reader["BillingAddress"]?.ToString(),
                        PaymentMethod = reader["PaymentMethod"].ToString()
                    });
                }
            }

            return payments;
        }

        public Payment GetPaymentById(string paymentId)
        {
            string query = "SELECT * FROM GetPaymentById WHERE PaymentId = @PaymentId";
            Payment payment = null;

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {

                cmd.Parameters.AddWithValue("@PaymentId", paymentId);
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

        public void UpdatePayment(Payment payment)
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

        public void DeletePayment(int paymentId)
        {
            var query = "DELETE FROM Payment WHERE PaymentId = @PaymentId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@PaymentId", paymentId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}