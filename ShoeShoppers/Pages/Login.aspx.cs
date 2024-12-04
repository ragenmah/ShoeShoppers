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
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LoginBtn_Click(object sender, EventArgs e)
        {

            String email = txtEmail.Text;

            Session["email"] = email;

            HttpCookie userCookie = new HttpCookie("email");
            userCookie.Value = email;
            userCookie.Expires = DateTime.Now.AddDays(1); 

            // Add the cookie to the Response
            Response.Cookies.Add(userCookie);


            Response.Redirect("/admin");

          


        }

       
    }
}