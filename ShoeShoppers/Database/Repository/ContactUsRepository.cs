using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class ContactUsRepository
    {
        private readonly SqlConnection _connection;

        public ContactUsRepository()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }

        public List<ContactUs> GetContactUsList()
        {
            List<ContactUs> contactList = new List<ContactUs>();
            string query = "SELECT * FROM ContactUs";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contactList.Add(new ContactUs
                        {
                            ContactUsId = Convert.ToInt32(reader["ContactUsId"]),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Message = reader["Message"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            IsReplied = Convert.ToBoolean(reader["IsReplied"]),
                            RepliedAt = reader["RepliedAt"] as DateTime?,
                            RepliedBy = reader["RepliedBy"].ToString()
                        });
                    }
                }
            }

            return contactList;
        }
        
        public void AddContactUs(ContactUs contact)
        {
            string query = "INSERT INTO ContactUs (FullName, Email, PhoneNumber, Message, CreatedAt, IsReplied) " +
                        "VALUES (@FullName, @Email, @PhoneNumber, @Message, @CreatedAt, @IsReplied)";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                
                cmd.Parameters.AddWithValue("@FullName", contact.FullName);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsReplied", false);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateContactUs(ContactUs contact)
        {
            string query = "UPDATE ContactUs SET FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber, " +
                           "Message = @Message, IsReplied = @IsReplied, RepliedAt = @RepliedAt, RepliedBy = @RepliedBy " +
                           "WHERE ContactUsId = @ContactUsId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@FullName", contact.FullName);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
                cmd.Parameters.AddWithValue("@IsReplied", contact.IsReplied);
                cmd.Parameters.AddWithValue("@RepliedAt", contact.RepliedAt ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@RepliedBy", contact.RepliedBy ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ContactUsId", contact.ContactUsId);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteContactUs(int contactUsId)
        {
            string query = "DELETE FROM ContactUs WHERE ContactUsId = @ContactUsId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ContactUsId", contactUsId);
                cmd.ExecuteNonQuery();
            }
        }


       
    }
}