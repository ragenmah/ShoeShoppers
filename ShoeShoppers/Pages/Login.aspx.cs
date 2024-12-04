using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}