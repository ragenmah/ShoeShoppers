using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages
{
    public partial class ProductDetail : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            string productId = Page.RouteData.Values["id"] as string;
            if (productId != null)
            {
                // Use the productId to load product details or handle logic
            }
        }
    }
}