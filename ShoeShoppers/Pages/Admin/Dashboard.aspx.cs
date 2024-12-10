using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserLogin"] != null)
            {
              
                string email = Request.Cookies["UserLogin"]["Email"];

               
                lblWelcome.Text = "You are logged as " + email;
            }
            else
            {
                lblWelcome.Text = "No user data found in cookie.";
            }
        }
    }
}