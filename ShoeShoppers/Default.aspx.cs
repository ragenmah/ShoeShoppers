using ShoeShoppers.Database.Repository;
using ShoeShoppers.Pages;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers
{
    public partial class _Default : Page
    {

        private ProductService _productService = new ProductService(new ProductRepository());
        private readonly CategoryService _categoryService = new CategoryService(new CategoryRepository());

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            rptProducts.DataSource = _productService.GetAllProducts();
            rptProducts.DataBind();
        }

        private void LoadCategories()
        {
            rptCategories.DataSource = _categoryService.GetAllCategories();
            rptCategories.DataBind();
        }
    }
}