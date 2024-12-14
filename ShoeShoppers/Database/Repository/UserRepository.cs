using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }

        public void AddUser(User user)
        {
            string query = @"
                    INSERT INTO Users (FirstName, LastName, Email, Password, RoleId, MobileNumber, DateOfBirth, Address, City, PostalCode, Country, AccountImage)
                    VALUES (@FirstName, @LastName, @Email, @Password, @RoleId, @MobileNumber, @DateOfBirth, @Address, @City, @PostalCode, @Country, @AccountImage)";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
                cmd.Parameters.AddWithValue("@MobileNumber", user.MobileNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@City", user.City ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PostalCode", user.PostalCode ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Country", user.Country ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AccountImage", user.AccountImage ?? (object)DBNull.Value);
               
                cmd.ExecuteNonQuery();
            }
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT * FROM Users";
            List<User> users = new List<User>();

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        MobileNumber = reader["MobileNumber"]?.ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]??DateTime.Now),
                        Address = reader["Address"]?.ToString(),
                        City = reader["City"]?.ToString(),
                        PostalCode = reader["PostalCode"]?.ToString(),
                        Country = reader["Country"]?.ToString(),
                        AccountImage = reader["AccountImage"]?.ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                    });
                }
            }

            return users;
        }

        public User GetUserById(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserId = @UserId";
            User user = null;

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {

                cmd.Parameters.AddWithValue("@UserId", userId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        MobileNumber = reader["MobileNumber"]?.ToString(),
                        DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DateOfBirth"]),
                        Address = reader["Address"]?.ToString(),
                        City = reader["City"]?.ToString(),
                        PostalCode = reader["PostalCode"]?.ToString(),
                        Country = reader["Country"]?.ToString(),
                        AccountImage = reader["AccountImage"]?.ToString(),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                    };
                }
            }

            return user;
        }

        public void UpdateUser(User user)
        {
            string query = @"
                    UPDATE Users
                    SET FirstName = @FirstName, LastName = @LastName, 
                        MobileNumber = @MobileNumber, DateOfBirth = @DateOfBirth, Address = @Address, City = @City,
                        PostalCode = @PostalCode, Country = @Country, AccountImage = @AccountImage, UpdatedAt = GETDATE()
                    WHERE UserId = @UserId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
           
         
              
                cmd.Parameters.AddWithValue("@MobileNumber", user.MobileNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", user.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@City", user.City ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PostalCode", user.PostalCode ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Country", user.Country ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@AccountImage", user.AccountImage ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int userId)
        {
            var query = "DELETE FROM Users WHERE UserId = @UserId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}