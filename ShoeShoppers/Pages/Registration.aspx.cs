using ShoeShoppers.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = string.Empty; 
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string reEnteredPassword = txtReEnteredPassword.Text.Trim();

            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(reEnteredPassword))
            {
                lblMessage.Text = "All fields are required.";
                return;
            }
            else if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(reEnteredPassword))
            {
                if (password != reEnteredPassword) {
                    lblMessage.Text = "Password does not match. Please re-enter again.";
                    return;
                }
            }


            try
            {
                SqlConnection connection = DatabaseConnection.Instance.GetConnection();

                string registerMember = @"
            INSERT INTO Users (FirstName, LastName, Email, Password, RoleId, CreatedAt)
            VALUES (@FirstName, @LastName, @Email, @Password, @RoleId, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(registerMember, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email); 
                    cmd.Parameters.AddWithValue("@Password", password);
                    //cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@RoleId", 2);

                    
                    cmd.ExecuteNonQuery();

                    lblMessage.Text = "Registration successful!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";

            }
            finally
            {
               
                DatabaseConnection.Instance.CloseConnection();
            }
        }
    }
}