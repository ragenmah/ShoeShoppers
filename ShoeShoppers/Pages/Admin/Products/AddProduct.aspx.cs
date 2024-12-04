using ShoeShoppers.Model;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages.Admin.Products
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private ProductService _service = new ProductService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Description = txtDescription.Text,
                Stock = int.Parse(txtStock.Text)
            };
            _service.AddProduct(product);
            Response.Redirect("/product-list");
        }
    }
}