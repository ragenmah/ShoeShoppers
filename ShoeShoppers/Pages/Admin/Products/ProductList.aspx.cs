using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages.Admin.Products
{
    public partial class ProductList : System.Web.UI.Page
    {
        private ProductService _service = new ProductService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            GridView1.DataSource = _service.GetAllProducts();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int productId = Convert.ToInt32(GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                Response.Redirect($"EditProduct.aspx?ProductId={productId}");
            }
            else if (e.CommandName == "Delete")
            {
                int productId = Convert.ToInt32(GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
                _service.DeleteProduct(productId);
                LoadProducts();
            }
        }
    }
}