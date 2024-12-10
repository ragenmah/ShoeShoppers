using ShoeShoppers.Database.Repository;
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
        private ProductService _service;
        public ProductList()
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
            gvProducts.DataSource = _service.GetAllProducts();
            gvProducts.DataBind();
        }

        protected void AddProduct(object sender, EventArgs e)
        {
            // Redirect to a product creation form or open a modal
        }

        protected void EditProduct(object sender, GridViewEditEventArgs e)
        {
            // Logic for editing product
        }

        protected void DeleteProduct(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value); 
            _service.DeleteProduct(productId);
            LoadProducts();
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ImageClick")
                {
                   
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
 
                    int productId = Convert.ToInt32(gvProducts.DataKeys[rowIndex].Value);
                     
                    Response.Redirect($"/add-product-images/{productId}");
                }
                else
                if (e.CommandName == "Edit" || e.CommandName == "Delete")
                {
                  
                    int rowIndex = Convert.ToInt32(e.CommandArgument); 
                   
                    int productId = Convert.ToInt32(gvProducts.DataKeys[rowIndex].Value);

                    if (e.CommandName == "Edit")
                    {
                        Response.Redirect($"/edit-product/{productId}");
                    }
                    else if (e.CommandName == "Delete")
                    {
                        _service.DeleteProduct(productId);
                        LoadProducts(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}