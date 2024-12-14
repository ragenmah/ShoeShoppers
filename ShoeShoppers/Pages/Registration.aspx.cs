using ShoeShoppers.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCrypt.Net;

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

        private bool CheckIfEmailExists(string email)
        {
            bool emailExists = false;
            try
            {
                using (SqlConnection connection = DatabaseConnection.Instance.GetConnection())
                {
                    string emailCheckQuery = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(emailCheckQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int result = (int)cmd.ExecuteScalar();
                        emailExists = result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            return emailExists;
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {

            string connectionString = "data source=DESKTOP-AV3JEH2;initial catalog=SimonNectieDB;trusted_connection=False; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: {ex.Message}");
                }
            }

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

                //if (CheckIfEmailExists(email))
                //{
                //    lblMessage.Text = "The email is already registered. Please use a different email.";
                //    return;
                //}

                string emailCheckQuery = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
                using (SqlCommand emailCheckCmd = new SqlCommand(emailCheckQuery, connection))
                {
                    emailCheckCmd.Parameters.AddWithValue("@Email", email);
                    int emailExists = (int)emailCheckCmd.ExecuteScalar();

                    if (emailExists > 0)
                    {
                        lblMessage.Text = "The email is already registered. Please use a different email.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return; // Exit if the email is already in use
                    }
                }



                string registerMember = @"
            INSERT INTO Users (FirstName, LastName, Email, Password, RoleId)
            VALUES (@FirstName, @LastName, @Email, @Password, @RoleId)";

                using (SqlCommand cmd = new SqlCommand(registerMember, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email); 
                    cmd.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(password));
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