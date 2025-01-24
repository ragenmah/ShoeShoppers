using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages.Admin
{
    public partial class Admin : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["UserLogin"] == null)
            {
                Response.Redirect("~/login");
            }
        }
    }
}