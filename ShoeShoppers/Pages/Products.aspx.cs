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
        private ProductService _productService; 
        private readonly CategoryService _categoryService ;

        public Products()
        {
            _productService = new ProductService(new ProductRepository());
            _categoryService = new CategoryService(new CategoryRepository());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategories();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("All", ""));

        }

        private void LoadProducts()
        {
            rptProducts.DataSource = _productService.GetAllProducts();
            rptProducts.DataBind();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlCategory.SelectedValue;

            if (string.IsNullOrEmpty(selectedValue))
            {
                LoadProducts();
            }
            else
            {
                rptProducts.DataSource = _productService.GetAllProductsByCategory(selectedValue);
                rptProducts.DataBind();
            }

        }
    }
}