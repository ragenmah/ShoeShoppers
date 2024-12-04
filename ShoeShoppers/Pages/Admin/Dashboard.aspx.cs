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
            if (Request.Cookies["email"] != null)
            {
                // Retrieve the cookie value
                string email = Request.Cookies["email"].Value;

                // Display the username in a label or another control
                lblWelcome.Text =  email;
            }
            else
            {
                lblWelcome.Text = "No user data found in cookie.";
            }
        }
    }
}