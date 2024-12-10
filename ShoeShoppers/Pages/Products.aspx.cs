using ShoeShoppers.Database.Repository;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages
{
    public partial class Products : System.Web.UI.Page
    {
        private ProductService _service;
        public Products()
        {
            _service = new ProductService(new ProductRepository());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            rptProducts.DataSource = _service.GetAllProducts();
            rptProducts.DataBind();
        }
    }
}