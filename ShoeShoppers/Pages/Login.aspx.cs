using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


using ShoeShoppers.Database;

namespace ShoeShoppers
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Session["email"] =this. TextBoxEmail.Text;

            HttpCookie userCookie = new HttpCookie("email");
            userCookie.Value = this.TextBoxEmail.Text; ;
            userCookie.Expires = DateTime.Now.AddDays(1); 

            // Add the cookie to the Response
            Response.Cookies.Add(userCookie);


            Response.Redirect("/admin");

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            //string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) )
            {
                lblMessage.Text = "All fields are required.";
                return;
            }

            try
            {
                SqlConnection connection = DatabaseConnection.Instance.GetConnection();

                using (SqlCommand cmd = new SqlCommand("RegisterMember", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    //cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    //cmd.Parameters.AddWithValue("@Gender", gender);

                    cmd.ExecuteNonQuery();

                    lblMessage.Text = "Registration successful!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";

            }


        }
    }
}