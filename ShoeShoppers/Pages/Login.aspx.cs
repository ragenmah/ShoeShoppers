using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


using ShoeShoppers.Database;

namespace ShoeShoppers.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        string userRole = string.Empty;
        string userId;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool IsValidUser(string email, string password)
        {

            string query = "SELECT UserId, Password, RoleId FROM Users WHERE Email = @Email";
            try
            {
                SqlConnection connection = DatabaseConnection.Instance.GetConnection();
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", email);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string storedPassword = reader["Password"].ToString();
                            int roleId = Convert.ToInt32(reader["RoleId"]);
                            userRole = GetUserRole(roleId);
                            userId = reader["UserId"].ToString();

                            if (roleId == 1)
                            {
                                return true;
                            }
                            else
                            if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                            {

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";
            }


            return false;
        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (IsValidUser(email, password))
            {
                HttpCookie loginCookie = new HttpCookie("UserLogin");

                loginCookie["Email"] = email;
                loginCookie["Role"] = userRole;
                loginCookie["userId"] = userId;

                if (chkRememberMe.Checked)
                {

                    loginCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(loginCookie);
                }

                else
                {
                    loginCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(loginCookie);
                }


                if (userRole == "Admin")
                {  Response.Redirect("/admin");
                }
                else
                {
                    Response.Redirect("/");
                }
            }
            else
            {
                lblMessage.Text = "Invalid email or password.";
            }

        }

        private string GetUserRole(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    return "Admin";
                case 2:
                    return "User";
                default:
                    return "Guest";
            }
        }
    }
}